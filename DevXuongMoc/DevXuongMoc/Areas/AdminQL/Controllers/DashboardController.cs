using DevXuongMoc.Areas.AdminQL.Controllers;
using DevXuongMoc.Controllers;
using DevXuongMoc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DevXuongMoc.Areas.Controllers
{
    public class DashboardController : BaseController
    {

        public readonly XuongMocContext _context;
        private readonly ILogger<DashboardController> _logger;

        public DashboardController(ILogger<DashboardController> logger, XuongMocContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var products = _context.Products.Take(4).ToList();
            return View(products);

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
