using Microsoft.AspNetCore.Mvc;
using PET_DOGCAT.Areas.CustomerUser.Controllers;

namespace PET_DOGCAT.Areas.CustomerUser.Controllers
{
    public class DashboardController : BaseController
    {
        public IActionResult Index(int? id)
        {
            return View();
        }
    }
}
