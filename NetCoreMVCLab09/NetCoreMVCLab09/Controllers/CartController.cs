using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;
using NetCoreMVCLab09.Models;
using Newtonsoft.Json;


namespace NetCoreMVCLab09.Controllers
{
    public class CartController : Controller, IActionFilter
    {
        private readonly DevXuongMocContext _context;
        private List<Cart> carts = new List<Cart>();
        public CartController(DevXuongMocContext context)
        {
            _context = context;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var cartInSession = HttpContext.Session.GetString("My-Cart"); if (cartInSession != null)
            {
                // nếu cartInSession không null thì gán dữ liệu cho biến carts  // Chuyển san dữ liệu json 
                carts = JsonConvert.DeserializeObject<List<Cart>>(cartInSession);
            }
            base.OnActionExecuting(context);
        }


        public IActionResult Index()
        {
            float total = 0;
            foreach (var item in carts)
            {
                total += item.Quantity * item.Price;
            }
            ViewBag.total = total; // Tổng tiền của đơn hàng 
            return View(carts);
        }
        /// <summary>
        /// Code logic cho chức năng thêm sản phẩm vào giỏ hàng 
        /// </summary> 
        /// <param name="id"></param> 
        /// <returns></returns> 
        public IActionResult Add(int id)
        {
            if (carts.Any(c => c.Id == id)) // nếu sản phẩm này đã có trong giỏ hàng
            {
                carts.Where(c => c.Id == id).First().Quantity += 1; // Tăng số lượng
            }
            else // Nếu sản phẩm chưa có trong giỏ hàng, thêm sản phẩm vào giỏ hàng
            {
                var p = _context.Products.Find(id); // tìm sản phẩm cần mua trong bảng sản  phẩm 
                                                    // tạo mới một sản phẩm để thêm vào giỏ hàng 
                var item = new Cart()
                {
                    Id = p.Id,
                    Name = p.Title,
                    Price = (float)p.PriceNew.Value,
                    Quantity = 1,
                    Image = p.Image,
                    Total = (float)p.PriceNew.Value * 1
                };
                // thêm sản phẩm vào giỏ hàng 
                carts.Add(item);
            }
            // lưu carts vào session, cần phải chuyển sang dữ liệu json
            HttpContext.Session.SetString("My-Cart", JsonConvert.SerializeObject(carts));
            return RedirectToAction("Index");
        }
        /// <summary> 
        /// Code logic cho chức năng xóa sản phẩm trong giỏ hàng  
        /// </summary> 
        /// <param name="id"></param> 
        /// <returns></returns> 
        public IActionResult Remove(int id)
        {
            if (carts.Any(c => c.Id == id))
            {
                // tìm sản phẩm trong giỏ hàng 
                var item = carts.Where(c => c.Id == id).First();
                //thực hiện xóa  
                carts.Remove(item);
                // lưu carts vào session, cần phải chuyển sang dữ liệu json
                HttpContext.Session.SetString("My-Cart", JsonConvert.SerializeObject(carts));
            }
            return RedirectToAction("Index");
        }
        /// <summary> 
        /// Code logic cho chức năng cập nhật dữ liệu trong giỏ hàng  
        /// </summary>
        /// <param name="id"></param> 
        /// <param name="quantity"></param> 
        /// <returns></returns> 
        public IActionResult Update(int id, int quantity)
        {
            if (carts.Any(c => c.Id == id))
            {
                // tìm sản phẩm trong giỏ hàng và cập nhật lại số lượng mới
                carts.Where(c => c.Id == id).First().Quantity = quantity;
                // lưu carts vào session, cần phải chuyển sang dữ liệu json
                HttpContext.Session.SetString("My-Cart", JsonConvert.SerializeObject(carts));
            }
            return RedirectToAction("Index");
        }
        /// <summary> 
        /// Code logic cho chức năng xóa hết sản phẩm trong giỏ hàng 
        /// </summary> 
        /// <returns></returns> 
        public IActionResult Clear()
        {
            HttpContext.Session.Remove("My-Cart");
            return RedirectToAction("Index");
        }


        /// <summary> 
        /// Code logic để hiển thị thông tin giỏ hàng;  
        /// Dữ liệu giỏ hàng trong session cart 
        /// </summary> 
        /// <returns></returns> 
        public IActionResult Orders()
        {
            if (HttpContext.Session.GetString("Member") == null)
            {
                // nếu người dùng chưa đăng nhập
                return Redirect("/customermember/index/?url=/cart/orders");
            }
            else
            {
                var dataMember = JsonConvert.DeserializeObject<Customer>(HttpContext.Session.GetString("Member"));
                ViewBag.Customer = dataMember;

                float total = 0;
                foreach (var item in carts)
                {
                    total += item.Quantity * item.Price;
                }
                ViewBag.total = total;

                // Phương thức thanh toán
                var dataPay = _context.PaymentMethods.ToList();
                ViewData["IdPayment"] = new SelectList(dataPay, "Id", "Name", true);
            }
            return View(carts);
        }

        /// <summary> 
        /// Khi người dùng click vào nút thanh toán: 
        /// - Thực hiện thêm dữ liệu vào bảng Orders, OrderDetails 
        /// - Giải phóng session cart 
        /// </summary> 
        /// <param name="form"></param> 
        /// <returns></returns> 
        public async Task<IActionResult> OrderPay(IFormCollection form)
        {
            try
            {
                // Thêm bảng orders 
                var order = new Order();
                order.NameReceiver = form["NameReceiver"];
                order.Email = form["Email"];
                order.Phone = form["Phone"];
                order.Address = form["Address"];
                order.Notes = form["Notes"];
                order.Idpayment = (int?)long.Parse(form["Idpayment"]); // Chuyển đổi tường minh
                order.OrdersDate = DateTime.Now;

                var dataMember = JsonConvert.DeserializeObject<Customer>(HttpContext.Session.GetString("Member"));
                order.Idcustomer = dataMember.Id;

                decimal total = 0;
                foreach (var item in carts)
                {
                    total += item.Quantity * (decimal)item.Price;
                }
                order.TotalMoney = total;

                // Tạo orderId 
                var strOrderId = "DH";
                string timestamp = DateTime.Now.ToString("yyyyMMddss");
                strOrderId += timestamp;
                order.Idorders = strOrderId;

                _context.Add(order);
                await _context.SaveChangesAsync();

                // Lấy id bảng orders 
                var dataOrder = _context.Orders.OrderByDescending(x => x.Id).FirstOrDefault();

                foreach (var item in carts)
                {
                    OrdersDetail od = new OrdersDetail();
                    od.Idord = (int)(int?)dataOrder.Id; // Chuyển đổi tường minh
                    od.Idproduct = item.Id;
                    od.Qty = item.Quantity;
                    od.Price = (decimal)item.Price;
                    od.Total = (decimal)item.Total;
                    od.ReturnQty = 0;

                    _context.Add(od);
                    await _context.SaveChangesAsync();
                }

                HttpContext.Session.Remove("My-Cart");
            }
            catch (Exception ex)
            {
                // Nên log lỗi thay vì ném ngoại lệ trống
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }

            return RedirectToAction("Index");
        }



    }
}
