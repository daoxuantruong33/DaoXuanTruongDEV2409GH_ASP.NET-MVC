using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using NetCoreMVCLab09.Models;
using Newtonsoft.Json;
using NuGet.Protocol;
using Login = NetCoreMVCLab09.Models.LoginUser;

namespace NetCoreMVCLab09.Controllers
{
    public class CustomerMemberController : Controller
    {
        private readonly DevXuongMocContext _context;
        public CustomerMemberController(DevXuongMocContext context)
        {
            _context = context;
        }

        public IActionResult Index(string url)
        {
            if (HttpContext.Session.GetString("Member") != null)
            {
                var dataLogin = JsonConvert.DeserializeObject<Customer>(HttpContext.Session.GetString("Member"));
                ViewBag.Customer = dataLogin;
            }
            ViewBag.UrlAction = url;
            return View();
        }


        [HttpPost]
        public IActionResult Registy(Customer model)
        {
            try
            {
                var pass = model.Password;
                model.Password = pass;
                model.CreatedDate = DateTime.Now;
                model.UpdatedDate = DateTime.Now;
                model.Isactive = true;
                _context.Add(model);
                _context.SaveChanges();
                return View();
            }
            catch (Exception ex)
            {
                TempData["errorRegisty"] = "Lỗi đăng ký; " + ex.Message; 
                return RedirectToAction("Index");
            }

        }

        /// <summary> 
        /// Chức năng đăng nhập 
        /// </summary> 
        /// <param name="model"></param> 
        /// <param name="urlAction"></param> 
        /// <returns></returns> 
        [HttpPost]
        public IActionResult Login(LoginUser model, string urlAction)
        {
            var pass = model.Password;
            var data = _context.Customers.Where(x => x.Isactive == true).Where(x => x.Username.Equals(model.UserOrEmail) || x.Email.Equals(model.UserOrEmail)).FirstOrDefault(x => x.Password.Equals(pass)); 
            var dataLogin = data.ToJson();
            if (data != null)
            {
                // Lưu session khi đăng nhập thành công 
                HttpContext.Session.SetString("Member", dataLogin);
                if (!string.IsNullOrEmpty(urlAction))
                {
                    return Redirect(urlAction);
                }
                return RedirectToAction("Index");
            }
            TempData["errorLogin"] = "Lỗi đăng nhập";
            return RedirectToAction("Index");
        }


    }
}
