using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuanLyVienPhi.Models;

namespace QuanLyVienPhi.Areas.Admins.Controllers
{
    [Area("Admins")]
    public class ChiTietDichVusController : Controller
    {
        private readonly QuanLyVienPhiContext _context;

        public ChiTietDichVusController(QuanLyVienPhiContext context)
        {
            _context = context;
        }

        // GET: Admins/ChiTietDichVus
        public async Task<IActionResult> Index()
        {
            var quanLyVienPhiContext = _context.ChiTietDichVus.Include(c => c.BenhNhan).Include(c => c.DichVu);
            return View(await quanLyVienPhiContext.ToListAsync());
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

            return View(chiTietDichVu);
        }

        // GET: Admins/ChiTietDichVus/Create
        public IActionResult Create()
        {
            ViewData["BenhNhanId"] = new SelectList(_context.BenhNhans, "BenhNhanId", "HoTen");
            ViewData["DichVuId"] = new SelectList(_context.DichVus, "DichVuId", "DichVuId");
            return View();
        }

        // POST: Admins/ChiTietDichVus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ChiTietDichVuId,BenhNhanId,Cccd,DichVuId,TenDichVu,GiaTien")] ChiTietDichVu chiTietDichVu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chiTietDichVu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BenhNhanId"] = new SelectList(_context.BenhNhans, "BenhNhanId", "BenhNhanId", chiTietDichVu.BenhNhanId);
            ViewData["DichVuId"] = new SelectList(_context.DichVus, "DichVuId", "DichVuId", chiTietDichVu.DichVuId);
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
            ViewData["BenhNhanId"] = new SelectList(_context.BenhNhans, "BenhNhanId", "BenhNhanId", chiTietDichVu.BenhNhanId);
            ViewData["DichVuId"] = new SelectList(_context.DichVus, "DichVuId", "DichVuId", chiTietDichVu.DichVuId);
            return View(chiTietDichVu);
        }

        // POST: Admins/ChiTietDichVus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ChiTietDichVuId,BenhNhanId,Cccd,DichVuId,GiaTien")] ChiTietDichVu chiTietDichVu)
        {
            if (id != chiTietDichVu.ChiTietDichVuId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
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
                return RedirectToAction(nameof(Index));
            }
            ViewData["BenhNhanId"] = new SelectList(_context.BenhNhans, "BenhNhanId", "BenhNhanId", chiTietDichVu.BenhNhanId);
            ViewData["DichVuId"] = new SelectList(_context.DichVus, "DichVuId", "DichVuId", chiTietDichVu.DichVuId);
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
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chiTietDichVu = await _context.ChiTietDichVus.FindAsync(id);
            if (chiTietDichVu != null)
            {
                _context.ChiTietDichVus.Remove(chiTietDichVu);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
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
