using Microsoft.AspNetCore.Mvc;

namespace DevXuongMoc.Areas.AdminQL.Controllers
{
    public class DashboardController : Controller
    {
        [Area("AdminQL")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
