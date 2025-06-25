using Microsoft.AspNetCore.Mvc;
using QuanLyVienPhi.Areas.Admins.Models;
using QuanLyVienPhi.Models;
using System.Security.Cryptography;
using System.Text;
namespace QuanLyVienPhi.Areas.Admins.Controllers
{
    [Area("Admins")]
    public class LoginController : Controller
    {
        private readonly QuanLyVienPhiContext _context;
        public LoginController(QuanLyVienPhiContext context)
        {
            _context = context;
        }

        [HttpGet] // Hiển thị form đăng nhập
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost] // Xử lý khi người dùng submit form đăng nhập
        public IActionResult Index(Login model)
        {
            if (!ModelState.IsValid)
            {
                return View(model); // Trả về trạng thái lỗi nếu form không hợp lệ
            }

            // Xử lý logic đăng nhập
            var pass = GetSHA26Hash(model.Password);
            var dataLogin = _context.Admins
            .Where(x => x.Email.Equals(model.Email) && x.Password.Equals(pass))
            .FirstOrDefault();

            if (dataLogin != null)
            {
                // Lưu session khi đăng nhập thành công
                HttpContext.Session.SetString("AdminLogin", model.Email);
                HttpContext.Session.SetInt32("RoleId", (int)dataLogin.RoleId); // Lưu RoleId vào session

                // Điều hướng đến Dashboard theo role
                switch (dataLogin.RoleId)
                {
                    case 1: // Admin
                        return RedirectToAction("Admin", "Dashboard");
                    case 2: // Sales
                        return RedirectToAction("BacSi", "Dashboard");
                    case 3: // Nhóm mới
                        return RedirectToAction("ThuNgan", "Dashboard");
                   
                }
            }

            ModelState.AddModelError("", "Email hoặc mật khẩu không chính xác!");
            return View(model); // Nếu không đăng nhập thành công, trả về trang đăng nhập
        }


        [HttpGet] // Thoát đăng nhập, xóa session
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("AdminLogin"); // Xóa session với key AdminLogin
            HttpContext.Session.Remove("RoleId"); // Xóa session với key RoleId

            return RedirectToAction("Index"); // Chuyển hướng về trang đăng nhập
        }
        static string GetSHA26Hash(string input)
        {
            using (var sha256 = SHA256.Create()) // Sử dụng SHA256.Create() thay vì SHA256Managed()
            {
                var hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }
    }
}
