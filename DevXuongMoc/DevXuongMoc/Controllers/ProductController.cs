using Microsoft.AspNetCore.Mvc;

namespace DevXuongMoc.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
