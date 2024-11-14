using Microsoft.AspNetCore.Mvc;

namespace WebGiay.Areas.CustomerUsers.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index(int? id)
        {
            return View();
        }
    }
}
