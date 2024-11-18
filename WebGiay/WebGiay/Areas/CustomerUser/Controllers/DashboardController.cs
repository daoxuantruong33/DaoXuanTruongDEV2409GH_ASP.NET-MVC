using Microsoft.AspNetCore.Mvc;
using WebGiay.Areas.CustomerUser.Controllers;

namespace WebGiay.Areas.CustomerUser.Controllers
{
    public class DashboardController : BaseController
    {
        public IActionResult Index(int? id)
        {
            return View();
        }
    }
}
