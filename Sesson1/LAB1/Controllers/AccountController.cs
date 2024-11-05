using LAB1.Models;
using Microsoft.AspNetCore.Mvc;

namespace LAB1.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            List<Account> accounts = new List<Account>
            {
                new Account()
                {
                    Id = 1,Name="Hoàng Anh",
                    Email="anh@gmail.com",
                    Phone="033333333",
                    Address="Hà Nội",
                    Avatar=Url.Content("~/images/avartar/1.jpg"),
                    Gender=1,Bio="My name is small",
                    Birthday=new DateTime(1998,7,15)
                },
                new Account()
                {
                    Id = 2,Name="Trường Giang",
                    Email="giang@gmail.com",
                    Phone="033332333",
                    Address="Hải Dương",
                    Avatar=Url.Content("~/images/avartar/1.jpg"),
                    Gender=1,Bio="My name is small",
                    Birthday=new DateTime(1997,4,5)
                },
                new Account()
                {
                    Id = 2,Name="Trúc Bảo",
                    Email="bao@gmail.com",
                    Phone="034333333",
                    Address="Hà Nội",
                    Avatar=Url.Content("~/images/avartar/1.jpg"),
                    Gender=1,Bio="My name is small",
                    Birthday=new DateTime(1991,10,11)
                },
            };
            ViewBag.Accounts = accounts;
            return View();
        }
        //định nghĩa ueel và nam cho action
        [Route("ho-so-cua-toi", Name = "Profile")]
        public IActionResult Profile(int id)
        {
            //danh sác
            List<Account> accounts = new List<Account>
            {
                new Account()
                {
                    Id = 1,Name="Hoàng Anh",
                    Email="anh@gmail.com",
                    Phone="033333333",
                    Address="Hà Nội",
                    Avatar=Url.Content("~/images/avartar/1.jpg"),
                    Gender=1,Bio="My name is small",
                    Birthday=new DateTime(1998,7,15)
                },
                new Account()
                {
                    Id = 2,Name="Trường Giang",
                    Email="giang@gmail.com",
                    Phone="033332333",
                    Address="Hải Dương",
                    Avatar=Url.Content("~/images/avartar/1.jpg"),
                    Gender=1,Bio="My name is small",
                    Birthday=new DateTime(1997,4,5)
                },
                new Account()
                {
                    Id = 2,Name="Trúc Bảo",
                    Email="bao@gmail.com",
                    Phone="034333333",
                    Address="Hà Nội",
                    Avatar=Url.Content("~/images/avartar/1.jpg"),
                    Gender=1,Bio="My name is small",
                    Birthday=new DateTime(1991,10,11)
                },
            };
            Account account = accounts.FirstOrDefault(ac => ac.Id == id);
            ViewBag.account = account;
            return View();
        }
    }
}
