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
    public class PhongsController : BaseController
    {
        private readonly QuanLyVienPhiContext _context;

        public PhongsController(QuanLyVienPhiContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string searchString = "", int page = 1, int pageSize = 5)
        {
            var phongsQuery = _context.Phongs.Include(p => p.Khoa).AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                phongsQuery = phongsQuery.Where(a => a.SoPhong.Contains(searchString));
            }

            int totalRecords = await phongsQuery.CountAsync();
            var phongs = await phongsQuery.OrderBy(a => a.PhongId)
                                          .Skip((page - 1) * pageSize)
                                          .Take(pageSize)
                                          .ToListAsync();

            ViewData["CurrentPage"] = page;
            ViewData["TotalPages"] = (int)Math.Ceiling((double)totalRecords / pageSize);

            return View(phongs);
        }

        // GET: Admins/Phongs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phong = await _context.Phongs
                .Include(p => p.Khoa)
                .FirstOrDefaultAsync(m => m.PhongId == id);
            if (phong == null)
            {
                return NotFound();
            }

            return View(phong);
        }

        // GET: Admins/Phongs/Create
        public IActionResult Create()
        {
            ViewData["KhoaId"] = new SelectList(_context.Khoas, "KhoaId", "TenKhoa");
            return View();
        }


        // POST: Admins/Phongs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PhongId,SoPhong,TienPhongNgay,KhoaId")] Phong phong)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phong);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KhoaId"] = new SelectList(_context.Khoas, "KhoaId", "KhoaId", phong.KhoaId);
            return View(phong);
        }


        // GET: Admins/Phongs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phong = await _context.Phongs.FindAsync(id);
            if (phong == null)
            {
                return NotFound();
            }
            ViewData["KhoaId"] = new SelectList(_context.Khoas, "KhoaId", "TenKhoa", phong.KhoaId);
            return View(phong);
        }


        // POST: Admins/Phongs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PhongId,SoPhong,TienPhongNgay,KhoaId")] Phong phong)
        {
            if (id != phong.PhongId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phong);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhongExists(phong.PhongId))
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
            ViewData["KhoaId"] = new SelectList(_context.Khoas, "KhoaId", "KhoaId", phong.KhoaId);
            return View(phong);
        }


        // GET: Admins/Phongs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phong = await _context.Phongs
                .Include(p => p.Khoa)
                .FirstOrDefaultAsync(m => m.PhongId == id);
            if (phong == null)
            {
                return NotFound();
            }

            return View(phong);
        }

        // POST: Admins/Phongs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var phong = await _context.Phongs.FindAsync(id);
            if (phong != null)
            {
                _context.Phongs.Remove(phong);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhongExists(int id)
        {
            return _context.Phongs.Any(e => e.PhongId == id);
        }
    }
}
