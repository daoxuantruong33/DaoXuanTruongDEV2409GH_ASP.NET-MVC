using Microsoft.AspNetCore.Mvc;

namespace WebQuanLySuKienAmNhac.Areas.AdminQL.Controllers
{
    public class DashboardController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
