using Microsoft.AspNetCore.Mvc;

namespace PET_DOGCAT.Areas.AdminQL.Controllers
{
    public class DashboardController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
