using Microsoft.AspNetCore.Mvc;
using QuanLyVienPhi.Areas.Admins.Models;

namespace QuanLyVienPhi.Areas.Admins.Controllers
{
    public class DashboardController : BaseController
    {
        private readonly DashboardService _dashboardService;

        public DashboardController(DashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        // Đây là action chung cho tất cả các dashboard
        public IActionResult Index()
        {
            var roleId = HttpContext.Session.GetInt32("RoleId"); // Lấy RoleId từ session

            if (roleId == null)
            {
                return RedirectToAction("Index", "Login"); // Nếu không có roleId trong session, điều hướng đến trang đăng nhập
            }

            // Điều hướng người dùng đến dashboard dựa trên roleId
            if (roleId == 1) // Admin
            {
                return RedirectToAction("Admin");
            }
            else if (roleId == 2) // Sales
            {
                return RedirectToAction("ThuNgan");
            }
            else if (roleId == 3) // Sales
            {
                return RedirectToAction("BacSi");
            }
            return RedirectToAction("Index", "Login"); // Nếu role không hợp lệ, quay lại đăng nhập
        }

        // Action dành cho Admin
        public IActionResult Admin()
        {
            var roleId = HttpContext.Session.GetInt32("RoleId");
            if (roleId != 1) // Nếu không phải Admin, redirect về trang đăng nhập
                return RedirectToAction("Index", "Login");

            var data = _dashboardService.GetDashboardData(); // Lấy dữ liệu cho Admin
            return View("Admin", data); // Truyền dữ liệu vào view AdminDashboard
        }

        // Action dành cho Sales
        public IActionResult BacSi()
        {
            var roleId = HttpContext.Session.GetInt32("RoleId");
            if (roleId != 2) // Nếu không phải Sales, redirect về trang đăng nhập
                return RedirectToAction("Index", "Login");

            var data = _dashboardService.GetDashboardData(); // Lấy dữ liệu cho Sales
            return View("BacSi", data); // Truyền dữ liệu vào view SalesDashboard
        }

        // Action dành cho Sales
        public IActionResult ThuNgan()
        {
            var roleId = HttpContext.Session.GetInt32("RoleId");
            if (roleId != 3) // Nếu không phải Sales, redirect về trang đăng nhập
                return RedirectToAction("Index", "Login");

            var data = _dashboardService.GetDashboardData(); // Lấy dữ liệu cho Sales
            return View("ThuNgan", data); // Truyền dữ liệu vào view SalesDashboard
        }
    }
}

