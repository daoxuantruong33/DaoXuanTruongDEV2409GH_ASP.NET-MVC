using Microsoft.AspNetCore.Mvc;

namespace QuanLyVienPhi.Areas.Admins.Controllers
{
    public class DashboardController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

