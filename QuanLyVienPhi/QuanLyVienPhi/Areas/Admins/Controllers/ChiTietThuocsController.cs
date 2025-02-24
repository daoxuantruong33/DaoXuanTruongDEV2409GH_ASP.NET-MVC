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
    public class ChiTietThuocsController : Controller
    {
        private readonly QuanLyVienPhiContext _context;

        public ChiTietThuocsController(QuanLyVienPhiContext context)
        {
            _context = context;
        }

        // GET: Admins/ChiTietThuocs
        public async Task<IActionResult> Index()
        {
            var quanLyVienPhiContext = _context.ChiTietThuocs.Include(c => c.BenhNhan).Include(c => c.Thuoc);
            return View(await quanLyVienPhiContext.ToListAsync());
        }

        // GET: Admins/ChiTietThuocs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chiTietThuoc = await _context.ChiTietThuocs
                .Include(c => c.BenhNhan)
                .Include(c => c.Thuoc)
                .FirstOrDefaultAsync(m => m.ChiTietThuocId == id);
            if (chiTietThuoc == null)
            {
                return NotFound();
            }

            return View(chiTietThuoc);
        }

        // GET: Admins/ChiTietThuocs/Create
        public IActionResult Create()
        {
            ViewData["BenhNhanId"] = new SelectList(_context.BenhNhans, "BenhNhanId", "BenhNhanId");
            ViewData["ThuocId"] = new SelectList(_context.Thuocs, "ThuocId", "ThuocId");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ChiTietThuocId,BenhNhanId,ThuocId,SoLuong,TienThuoc")] ChiTietThuoc chiTietThuoc)
        {
            if (ModelState.IsValid)
            {
                var thuoc = await _context.Thuocs.FindAsync(chiTietThuoc.ThuocId);
                if (thuoc != null)
                {
                    chiTietThuoc.TienThuoc = thuoc.GiaTien * chiTietThuoc.SoLuong;
                    Console.WriteLine($"Debug: GiaTien = {thuoc.GiaTien}, SoLuong = {chiTietThuoc.SoLuong}, TienThuoc = {chiTietThuoc.TienThuoc}");
                }

                _context.Add(chiTietThuoc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["BenhNhanId"] = new SelectList(_context.BenhNhans, "BenhNhanId", "BenhNhanId", chiTietThuoc.BenhNhanId);
            ViewData["ThuocId"] = new SelectList(_context.Thuocs, "ThuocId", "ThuocId", chiTietThuoc.ThuocId);
            return View(chiTietThuoc);
        }


        // GET: Admins/ChiTietThuocs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chiTietThuoc = await _context.ChiTietThuocs.FindAsync(id);
            if (chiTietThuoc == null)
            {
                return NotFound();
            }
            ViewData["BenhNhanId"] = new SelectList(_context.BenhNhans, "BenhNhanId", "BenhNhanId", chiTietThuoc.BenhNhanId);
            ViewData["ThuocId"] = new SelectList(_context.Thuocs, "ThuocId", "ThuocId", chiTietThuoc.ThuocId);
            return View(chiTietThuoc);
        }

        // POST: Admins/ChiTietThuocs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ChiTietThuocId,BenhNhanId,ThuocId,SoLuong,TienThuoc")] ChiTietThuoc chiTietThuoc)
        {
            if (id != chiTietThuoc.ChiTietThuocId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chiTietThuoc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChiTietThuocExists(chiTietThuoc.ChiTietThuocId))
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
            ViewData["BenhNhanId"] = new SelectList(_context.BenhNhans, "BenhNhanId", "BenhNhanId", chiTietThuoc.BenhNhanId);
            ViewData["ThuocId"] = new SelectList(_context.Thuocs, "ThuocId", "ThuocId", chiTietThuoc.ThuocId);
            return View(chiTietThuoc);
        }

        // GET: Admins/ChiTietThuocs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chiTietThuoc = await _context.ChiTietThuocs
                .Include(c => c.BenhNhan)
                .Include(c => c.Thuoc)
                .FirstOrDefaultAsync(m => m.ChiTietThuocId == id);
            if (chiTietThuoc == null)
            {
                return NotFound();
            }

            return View(chiTietThuoc);
        }

        // POST: Admins/ChiTietThuocs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chiTietThuoc = await _context.ChiTietThuocs.FindAsync(id);
            if (chiTietThuoc != null)
            {
                _context.ChiTietThuocs.Remove(chiTietThuoc);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChiTietThuocExists(int id)
        {
            return _context.ChiTietThuocs.Any(e => e.ChiTietThuocId == id);
        }



        [HttpGet]
        public async Task<IActionResult> GetDonGia(int id)
        {
            var thuoc = await _context.Thuocs.FindAsync(id);
            if (thuoc == null)
            {
                return NotFound();
            }
            return Json(thuoc.GiaTien);
        }

    }
}
