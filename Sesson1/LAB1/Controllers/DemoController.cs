using Microsoft.AspNetCore.Mvc;

namespace LAB1.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
