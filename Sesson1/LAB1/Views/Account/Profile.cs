using Microsoft.AspNetCore.Mvc;

namespace LAB1.Views.Account
{
    public class Profile : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
