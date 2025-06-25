using Microsoft.AspNetCore.Mvc;
using QuanLyVienPhi.Areas.Admins.Models;
using System.Drawing.Printing;

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
                return RedirectToAction("BacSi");
            }
            else if (roleId == 3) // Sales
            {
                return RedirectToAction("ThuNgan");
            }
            return RedirectToAction("Index", "Login"); // Nếu role không hợp lệ, quay lại đăng nhập
        }

        // Action dành cho Admin
        public IActionResult Admin(int pageNumber = 1, int pageSize = 10)
        {
            var roleId = HttpContext.Session.GetInt32("RoleId");
    

            var data = _dashboardService.GetDashboardData();
            var danhSachBenhNhan = _dashboardService.GetDanhSachBenhNhan(pageNumber, pageSize);
            var doanhThuTuanNay = _dashboardService.GetDoanhThuTuanNay();
            var doanhThuTheoNgay = _dashboardService.GetDoanhThuTheoNgay();

            // Lấy tỷ lệ chi phí
            var tiLeChiPhi = _dashboardService.GetTongChiPhi();

            // Chuyển dữ liệu doanh thu theo ngày thành JSON
            var labels = string.Join(",", doanhThuTheoNgay.Select(x => $"'{x.Ngay:yyyy-MM-dd}'"));
            var doanhThuData = string.Join(",", doanhThuTheoNgay.Select(x => x.DoanhThu.ToString("F0")));

            // Truyền dữ liệu ra View
            ViewBag.TotalBenhNhan = data.TongBenhNhan;
            ViewBag.DaThanhToan = data.DaThanhToan;
            ViewBag.ChuaThanhToan = data.ChuaThanhToan;
            ViewBag.TongDoanhThu = data.TongDoanhThu;
            ViewBag.DoanhThuTuanNay = doanhThuTuanNay;
            ViewBag.DanhSachBenhNhan = danhSachBenhNhan;
            ViewBag.DoanhThuTheoNgay = doanhThuTheoNgay;
            ViewBag.Labels = labels;
            ViewBag.DoanhThuData = doanhThuData;

            // Truyền dữ liệu biểu đồ tròn
            ViewBag.TiLeChiPhi = tiLeChiPhi;

            return View("Admin", data);
        }




        // Action dành cho Sales
        public IActionResult BacSi(int pageNumber = 1, int pageSize = 10)
        {
            var roleId = HttpContext.Session.GetInt32("RoleId");
        

            var data = _dashboardService.GetDashboardData(); // Lấy dữ liệu cho Sales
            var danhSachBenhNhan = _dashboardService.GetDanhSachBenhNhan(pageNumber, pageSize);
            var doanhThuTuanNay = _dashboardService.GetDoanhThuTuanNay();
            var doanhThuTheoNgay = _dashboardService.GetDoanhThuTheoNgay();

            // Lấy tỷ lệ chi phí
            var tiLeChiPhi = _dashboardService.GetTongChiPhi();

            // Chuyển dữ liệu doanh thu theo ngày thành JSON
            var labels = string.Join(",", doanhThuTheoNgay.Select(x => $"'{x.Ngay:yyyy-MM-dd}'"));
            var doanhThuData = string.Join(",", doanhThuTheoNgay.Select(x => x.DoanhThu.ToString("F0")));

            // Truyền dữ liệu ra View
            ViewBag.TotalBenhNhan = data.TongBenhNhan;
            ViewBag.DaThanhToan = data.DaThanhToan;
            ViewBag.ChuaThanhToan = data.ChuaThanhToan;
            ViewBag.TongDoanhThu = data.TongDoanhThu;
            ViewBag.DoanhThuTuanNay = doanhThuTuanNay;
            ViewBag.DanhSachBenhNhan = danhSachBenhNhan;
            ViewBag.DoanhThuTheoNgay = doanhThuTheoNgay;
            ViewBag.Labels = labels;
            ViewBag.DoanhThuData = doanhThuData;

            // Truyền dữ liệu biểu đồ tròn
            ViewBag.TiLeChiPhi = tiLeChiPhi;
            return View("BacSi", data); // Truyền dữ liệu vào view SalesDashboard
        }

        // Action dành cho Sales
        public IActionResult ThuNgan(int pageNumber = 1, int pageSize = 10)
        {
            var roleId = HttpContext.Session.GetInt32("RoleId");
           

            var data = _dashboardService.GetDashboardData(); // Lấy dữ liệu cho Sales
            var danhSachBenhNhan = _dashboardService.GetDanhSachBenhNhan(pageNumber, pageSize);
            var doanhThuTuanNay = _dashboardService.GetDoanhThuTuanNay();
            var doanhThuTheoNgay = _dashboardService.GetDoanhThuTheoNgay();

            // Lấy tỷ lệ chi phí
            var tiLeChiPhi = _dashboardService.GetTongChiPhi();

            // Chuyển dữ liệu doanh thu theo ngày thành JSON
            var labels = string.Join(",", doanhThuTheoNgay.Select(x => $"'{x.Ngay:yyyy-MM-dd}'"));
            var doanhThuData = string.Join(",", doanhThuTheoNgay.Select(x => x.DoanhThu.ToString("F0")));

            // Truyền dữ liệu ra View
            ViewBag.TotalBenhNhan = data.TongBenhNhan;
            ViewBag.DaThanhToan = data.DaThanhToan;
            ViewBag.ChuaThanhToan = data.ChuaThanhToan;
            ViewBag.TongDoanhThu = data.TongDoanhThu;
            ViewBag.DoanhThuTuanNay = doanhThuTuanNay;
            ViewBag.DanhSachBenhNhan = danhSachBenhNhan;
            ViewBag.DoanhThuTheoNgay = doanhThuTheoNgay;
            ViewBag.Labels = labels;
            ViewBag.DoanhThuData = doanhThuData;

            // Truyền dữ liệu biểu đồ tròn
            ViewBag.TiLeChiPhi = tiLeChiPhi;
            return View("ThuNgan", data); // Truyền dữ liệu vào view SalesDashboard
        }
    }
}

