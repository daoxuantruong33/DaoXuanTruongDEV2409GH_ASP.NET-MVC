using Microsoft.AspNetCore.Mvc;
using NetCoreMVCLab09.Lap.Areas.Admins.Controllers;

namespace NetCoreMVCLab09.Areas.Admin
{
  //  [Area("Admin")]
    public class DashboardController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
