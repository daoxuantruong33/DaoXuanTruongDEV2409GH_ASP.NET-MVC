using Microsoft.AspNetCore.Mvc;

namespace LAB1.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
