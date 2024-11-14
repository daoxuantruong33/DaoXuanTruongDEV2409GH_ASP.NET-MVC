using Microsoft.AspNetCore.Mvc;

namespace WebGiay.Areas.AdminQL.Controllers
{
    public class DashboardController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
