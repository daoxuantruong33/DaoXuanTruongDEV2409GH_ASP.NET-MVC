﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using PET_DOGCAT.Models;
using PET_DOGCAT.Areas.CustomerUser.Models;
using PET_DOGCAT.Areas.AdminQL.Models;
namespace PET_DOGCAT.Areas.CustomerUser.Controllers
{
    [Area("CustomerUser")]
    public class LoginController : Controller
    {
        public PetsDogcatContext _context;
        public LoginController(PetsDogcatContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost] // POST -> khi submit form
        public IActionResult Index(Login model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Thông tin đăng nhập không hợp lệ.");
                return View(model);
            }

            var pass = model.Password;
            var dataLogin = _context.Customers.FirstOrDefault(x => x.Email.Equals(model.Email) && x.Password.Equals(pass));
            if (dataLogin != null)
            {
                ViewBag.IsLoggedIn = true;
                HttpContext.Session.SetString("CustomerLogin", model.Email);
                HttpContext.Session.SetInt32("UserId", dataLogin.CustomerId);
                return RedirectToAction("Index", "Dashboard", new {userId = dataLogin.CustomerId});
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Thông tin đăng nhập không chính xác.");
                return View(model);
            }

        }
        [HttpGet]// thoát đăng nhập, huỷ session
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("CustomerLogin"); // huỷ session với key AdminLogin đã lưu trước đó

            return RedirectToAction("Index");
        }
    }
}