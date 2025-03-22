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
    public class GiuongsController : BaseController
    {
        private readonly QuanLyVienPhiContext _context;

        public GiuongsController(QuanLyVienPhiContext context)
        {
            _context = context;
        }

        // GET: Admins/Giuongs
        public async Task<IActionResult> Index()
        {
            var quanLyVienPhiContext = _context.Giuongs.Include(g => g.Phong);
            return View(await quanLyVienPhiContext.ToListAsync());
        }

        // GET: Admins/Giuongs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var giuong = await _context.Giuongs
                .Include(g => g.Phong)
                .FirstOrDefaultAsync(m => m.GiuongId == id);
            if (giuong == null)
            {
                return NotFound();
            }

            return View(giuong);
        }

        // GET: Admins/Giuongs/Create
        public IActionResult Create()
        {
            ViewData["PhongId"] = new SelectList(_context.Phongs, "PhongId", "PhongId");
            return View();
        }

        // POST: Admins/Giuongs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GiuongId,SoGiuong,PhongId,TrangThai")] Giuong giuong)
        {
            if (ModelState.IsValid)
            {
                _context.Add(giuong);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PhongId"] = new SelectList(_context.Phongs, "PhongId", "PhongId", giuong.PhongId);
            return View(giuong);
        }

        // GET: Admins/Giuongs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var giuong = await _context.Giuongs.FindAsync(id);
            if (giuong == null)
            {
                return NotFound();
            }
            ViewData["PhongId"] = new SelectList(_context.Phongs, "PhongId", "PhongId", giuong.PhongId);
            return View(giuong);
        }

        // POST: Admins/Giuongs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GiuongId,SoGiuong,PhongId,TrangThai")] Giuong giuong)
        {
            if (id != giuong.GiuongId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(giuong);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GiuongExists(giuong.GiuongId))
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
            ViewData["PhongId"] = new SelectList(_context.Phongs, "PhongId", "PhongId", giuong.PhongId);
            return View(giuong);
        }

        // GET: Admins/Giuongs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var giuong = await _context.Giuongs
                .Include(g => g.Phong)
                .FirstOrDefaultAsync(m => m.GiuongId == id);
            if (giuong == null)
            {
                return NotFound();
            }

            return View(giuong);
        }

        // POST: Admins/Giuongs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var giuong = await _context.Giuongs.FindAsync(id);
            if (giuong != null)
            {
                _context.Giuongs.Remove(giuong);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GiuongExists(int id)
        {
            return _context.Giuongs.Any(e => e.GiuongId == id);
        }
    }
}
