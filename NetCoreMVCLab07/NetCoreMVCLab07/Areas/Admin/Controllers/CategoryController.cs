using Microsoft.AspNetCore.Mvc;

namespace NetCoreMVCLab07.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
