using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using NetCoreMVCLab10_1.CustomAuthorize.Models;
using System.Diagnostics;
using System.Security.Claims;

namespace NetCoreMVCLab10_1.CustomAuthorize.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Login model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            // Xử lý kiểm tra logic ở đây
            if (model.Email != "admin@gmail.com" && model.Password != "123456")
            {
                ModelState.AddModelError(string.Empty, "Tài khoản không hợp lệ");
                return View(model);
            }
            // Xử lý lưu trữ vào cookie
            var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, model.Email) }, "DevSecuritySchema");
            var priciple = new ClaimsPrincipal(identity);
            HttpContext.SignInAsync("DevSecuritySchema", priciple);
            return RedirectToAction("Index", "Admin");
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
