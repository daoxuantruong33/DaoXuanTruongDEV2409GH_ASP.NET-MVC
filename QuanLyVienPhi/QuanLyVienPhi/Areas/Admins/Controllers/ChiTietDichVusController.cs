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
    public class ChiTietDichVusController : BaseController
    {
        private readonly QuanLyVienPhiContext _context;

        public ChiTietDichVusController(QuanLyVienPhiContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string searchString, int page = 1, int pageSize = 5)
        {
            var chitietdichvusQuery = _context.ChiTietDichVus
                .Include(c => c.BenhNhan)
                .Include(c => c.DichVu)
                .AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                chitietdichvusQuery = chitietdichvusQuery.Where(a => a.Cccd.Contains(searchString));
            }

            int totalRecords = await chitietdichvusQuery.CountAsync();
            var chitietdichvus = await chitietdichvusQuery
                .OrderBy(a => a.ChiTietDichVuId)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            TempData["CurrentPage"] = page;
            ViewData["CurrentPage"] = page;
            ViewData["TotalPages"] = (int)Math.Ceiling((double)totalRecords / pageSize);
            ViewData["SearchString"] = searchString;

            return View(chitietdichvus);
        }
        // GET: Admins/ChiTietDichVus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chiTietDichVu = await _context.ChiTietDichVus
                .Include(c => c.BenhNhan)
                .Include(c => c.DichVu)
                .FirstOrDefaultAsync(m => m.ChiTietDichVuId == id);
            if (chiTietDichVu == null)
            {
                return NotFound();
            }

            return PartialView("_DetailsPartial", chiTietDichVu);
        }

        // GET: Admins/ChiTietThuocs/Create
        public IActionResult Create(int? id)
        {
            ViewData["DichVuId"] = new SelectList(_context.DichVus, "DichVuId", "TenDichVu");

            if (id.HasValue)
            {
                var benhNhan = _context.BenhNhans.FirstOrDefault(b => b.BenhNhanId == id);
                if (benhNhan == null) return NotFound();

                var chiTietDichVu = new ChiTietDichVu
                {
                    BenhNhanId = benhNhan.BenhNhanId,
                    Cccd = benhNhan.Cccd,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                };

                ViewData["BenhNhanHoTen"] = benhNhan.HoTen;

                return View(chiTietDichVu);
            }

            ViewData["BenhNhanId"] = new SelectList(_context.BenhNhans, "BenhNhanId", "HoTen");
            return View();
        }

        // POST: Admins/ChiTietDichVus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ChiTietDichVuId,BenhNhanId,Cccd,DichVuId,TenDichVu,GiaTien,CreatedDate,UpdatedDate")] ChiTietDichVu chiTietDichVu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chiTietDichVu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BenhNhanId"] = new SelectList(_context.BenhNhans, "BenhNhanId", "BenhNhanId", chiTietDichVu.BenhNhanId);
            ViewData["DichVuId"] = new SelectList(_context.DichVus, "DichVuId", "TenDichVu", chiTietDichVu.DichVuId);
            return View(chiTietDichVu);
        }

        // GET: Admins/ChiTietDichVus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chiTietDichVu = await _context.ChiTietDichVus.FindAsync(id);
            if (chiTietDichVu == null)
            {
                return NotFound();
            }
            ViewData["BenhNhanId"] = new SelectList(_context.BenhNhans, "BenhNhanId", "HoTen", chiTietDichVu.BenhNhanId);
            ViewData["DichVuId"] = new SelectList(_context.DichVus, "DichVuId", "TenDichVu", chiTietDichVu.DichVuId);
            return PartialView("_EditPartial", chiTietDichVu);
        }

        // POST: Admins/ChiTietDichVus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ChiTietDichVuId,BenhNhanId,Cccd,DichVuId,GiaTien,CreatedDate,UpdatedDate")] ChiTietDichVu chiTietDichVu)
        {
            if (id != chiTietDichVu.ChiTietDichVuId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var existingChitietdichvus = await _context.ChiTietDichVus
                       .AsNoTracking()
                       .FirstOrDefaultAsync(b => b.ChiTietDichVuId == id);

                    if (existingChitietdichvus == null)
                    {
                        return NotFound();
                    }
                    _context.Update(chiTietDichVu);

                    // Giữ nguyên CreatedDate và cập nhật e
                    chiTietDichVu.CreatedDate = existingChitietdichvus.CreatedDate;
                    chiTietDichVu.UpdatedDate = DateTime.Now;


                    _context.Update(chiTietDichVu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChiTietDichVuExists(chiTietDichVu.ChiTietDichVuId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                int currentPage = TempData["CurrentPage"] != null ? (int)TempData["CurrentPage"] : 1;
                return RedirectToAction(nameof(Index), new { page = currentPage });
            }
            ViewData["BenhNhanId"] = new SelectList(_context.BenhNhans, "BenhNhanId", "HoTen", chiTietDichVu.BenhNhanId);
            ViewData["DichVuId"] = new SelectList(_context.DichVus, "DichVuId", "TenDichVu", chiTietDichVu.DichVuId);
            return View(chiTietDichVu);
        }

        // GET: Admins/ChiTietDichVus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chiTietDichVu = await _context.ChiTietDichVus
                .Include(c => c.BenhNhan)
                .Include(c => c.DichVu)
                .FirstOrDefaultAsync(m => m.ChiTietDichVuId == id);
            if (chiTietDichVu == null)
            {
                return NotFound();
            }

            return View(chiTietDichVu);
        }

        // POST: Admins/ChiTietDichVus/Delete/5
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var chiTietDichVu = _context.ChiTietDichVus.Find(id);
            if (chiTietDichVu != null)
            {
                _context.ChiTietDichVus.Remove(chiTietDichVu);
                _context.SaveChanges();
            }
            int currentPage = TempData["CurrentPage"] != null ? (int)TempData["CurrentPage"] : 1;
            return RedirectToAction(nameof(Index), new { page = currentPage });
        }

        private bool ChiTietDichVuExists(int id)
        {
            return _context.ChiTietDichVus.Any(e => e.ChiTietDichVuId == id);
        }

        [HttpGet]
        public JsonResult GetCccdByBenhNhanId(int benhNhanId)
        {
            var benhNhan = _context.BenhNhans.FirstOrDefault(b => b.BenhNhanId == benhNhanId);
            if (benhNhan != null)
            {
                return Json(new { cccd = benhNhan.Cccd });
            }
            return Json(new { cccd = "" });
        }

        [HttpGet]
        public JsonResult GetGiaTienByDichVuId(int dichVuId)
        {
            var dichVu = _context.DichVus.FirstOrDefault(d => d.DichVuId == dichVuId);
            if (dichVu != null)
            {
                return Json(new { giaTien = dichVu.GiaTien, tenDichVu = dichVu.TenDichVu });
            }
            return Json(new { giaTien = 0, tenDichVu = "" });
        }

    }
}
