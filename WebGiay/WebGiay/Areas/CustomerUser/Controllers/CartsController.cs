using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebGiay.Models;

namespace WebGiay.Areas.CustomerUser.Controllers
{
    public class CartsController : BaseController
    {
        private readonly QlBanHangContext _context;

        public CartsController(QlBanHangContext context)
        {
            _context = context;
        }

        // GET: CustomerUser/Carts
        public async Task<IActionResult> Index()
        {
            // Lấy userId từ Session
            var userId = HttpContext.Session.GetInt32("UserId");

            // Kiểm tra nếu không có userId trong session (nghĩa là người dùng chưa đăng nhập)
            if (userId == null)
            {
                // Nếu không có userId, có thể chuyển hướng về trang đăng nhập hoặc trang khác tùy theo yêu cầu của bạn
                return RedirectToAction("Login", "Account");  // Giả sử bạn có trang đăng nhập tại controller Account
            }

            // Lọc giỏ hàng của người dùng có userId cụ thể
            var webBanHangContext = _context.Carts
                .Include(c => c.Product)   // Kết hợp với bảng Product để lấy thông tin sản phẩm
                .Include(c => c.User)      // Kết hợp với bảng User (mặc dù bạn đã biết userId từ session, điều này có thể hữu ích cho một số trường hợp)
                .Where(c => c.UserId == userId)  // Chỉ lấy giỏ hàng của người dùng hiện tại
                .ToListAsync();            // Thực thi truy vấn bất đồng bộ

            // Trả kết quả về View, trong đó sẽ chứa giỏ hàng của người dùng
            return View(await webBanHangContext);
        }
        [HttpGet]
        public async Task<IActionResult> Add(int id)
        {
            // Lấy UserId từ session
            var userId = HttpContext.Session.GetInt32("UserId");

            // Kiểm tra nếu UserId không tồn tại trong session
            if (userId == null)
            {
                TempData["Error"] = "Bạn cần đăng nhập để sử dụng chức năng này.";
                return RedirectToAction("Index", "Login", new { area = "CustomerUser" });
            }

            // Kiểm tra nếu sản phẩm đã tồn tại trong giỏ hàng
            var existingCartItem = await _context.Carts
                .FirstOrDefaultAsync(c => c.ProductId == id && c.UserId == userId);

            if (existingCartItem != null)
            {
                // Tăng số lượng sản phẩm nếu đã tồn tại
                existingCartItem.Quantity++;
                _context.Carts.Update(existingCartItem);
            }
            else
            {
                // Thêm sản phẩm mới vào giỏ hàng
                var newCartItem = new Cart
                {
                    UserId = userId.Value, // UserId được lấy từ session
                    ProductId = id,
                    Quantity = 1 // Số lượng mặc định khi thêm mới
                };

                _context.Carts.Add(newCartItem);
            }

            // Lưu thay đổi vào cơ sở dữ liệu
            await _context.SaveChangesAsync();

            TempData["Success"] = "Sản phẩm đã được thêm vào giỏ hàng!";
            return RedirectToAction("Index", "Home");
        }
        // GET: CustomerUser/Carts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cart = await _context.Carts
                .Include(c => c.Product)
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.CartId == id);
            if (cart == null)
            {
                return NotFound();
            }

            return View(cart);
        }

        // GET: CustomerUser/Carts/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductId");
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId");
            return View();
        }

        // POST: CustomerUser/Carts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CartId,UserId,ProductId,Quantity")] Cart cart)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cart);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductId", cart.ProductId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", cart.UserId);
            return View(cart);
        }

        // GET: CustomerUser/Carts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cart = await _context.Carts.FindAsync(id);
            if (cart == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductId", cart.ProductId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", cart.UserId);
            return View(cart);
        }

        // POST: CustomerUser/Carts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CartId,UserId,ProductId,Quantity")] Cart cart)
        {
            if (id != cart.CartId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cart);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CartExists(cart.CartId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductId", cart.ProductId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", cart.UserId);
            return View(cart);
        }

        // GET: CustomerUser/Carts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cart = await _context.Carts
                .Include(c => c.Product)
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.CartId == id);
            if (cart == null)
            {
                return NotFound();
            }

            return View(cart);
        }

        // POST: CustomerUser/Carts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cart = await _context.Carts.FindAsync(id);
            if (cart != null)
            {
                _context.Carts.Remove(cart);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CartExists(int id)
        {
            return _context.Carts.Any(e => e.CartId == id);
        }
    }
}
