﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuanLyVienPhi.Models;

namespace QuanLyVienPhi.Areas.Admins.Controllers
{
    public class AdminsController : BaseController
    {
        private readonly QuanLyVienPhiContext _context;

        public AdminsController(QuanLyVienPhiContext context)
        {
            _context = context;
        }

        // GET: Admins/Admins
        public async Task<IActionResult> Index(string searchString, int page = 1, int pageSize = 5)
        {
            var adminsQuery = _context.Admins.AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                adminsQuery = adminsQuery.Where(a => a.FullName.Contains(searchString) || a.Username.Contains(searchString));
            }

            int totalRecords = await adminsQuery.CountAsync();
            var admins = await adminsQuery.OrderBy(a => a.AdminId)
                                          .Skip((page - 1) * pageSize)
                                          .Take(pageSize)
                                          .ToListAsync();

            ViewData["CurrentPage"] = page;
            ViewData["TotalPages"] = (int)Math.Ceiling((double)totalRecords / pageSize);

            return View(admins);
        }


        // GET: Admins/Admins/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admin = await _context.Admins
                .FirstOrDefaultAsync(m => m.AdminId == id);
            if (admin == null)
            {
                return NotFound();
            }

            return PartialView("_DetailsPartial", admin);
        }

        // GET: Admins/Admins/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admins/Admins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AdminId,Username,Password,FullName,Phone,Email,RoleId")] Admin admin)
        {
            if (ModelState.IsValid)
            {
                _context.Add(admin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(admin);
        }

        // GET: Admins/Admins/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admin = await _context.Admins.FindAsync(id);
            if (admin == null)
            {
                return NotFound();
            }
            return PartialView("_EditPartial", admin);
        }

        // POST: Admins/Admins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AdminId,Username,Password,FullName,Phone,Email,RoleId")] Admin admin)
        {
            if (id != admin.AdminId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(admin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdminExists(admin.AdminId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(admin);
        }

        // GET: Admins/Admins/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admin = await _context.Admins
                .FirstOrDefaultAsync(m => m.AdminId == id);
            if (admin == null)
            {
                return NotFound();
            }

            return View(admin);
        }

        // POST: Admins/ChiTietDichVus/Delete/5
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var admin = _context.Admins.Find(id);
            if (admin != null)
            {
                _context.Admins.Remove(admin);
                _context.SaveChanges();
            }
            int currentPage = TempData["CurrentPage"] != null ? (int)TempData["CurrentPage"] : 1;
            return RedirectToAction(nameof(Index), new { page = currentPage });
        }
        private bool AdminExists(int id)
        {
            return _context.Admins.Any(e => e.AdminId == id);
        }
    }
}
