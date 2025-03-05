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
    public class DoiTuongsController : BaseController
    {
        private readonly QuanLyVienPhiContext _context;

        public DoiTuongsController(QuanLyVienPhiContext context)
        {
            _context = context;
        }

        // GET: Admins/DoiTuongs
        public async Task<IActionResult> Index()
        {
            return View(await _context.DoiTuongs.ToListAsync());
        }

        // GET: Admins/DoiTuongs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doiTuong = await _context.DoiTuongs
                .FirstOrDefaultAsync(m => m.DoiTuongId == id);
            if (doiTuong == null)
            {
                return NotFound();
            }

            return View(doiTuong);
        }

        // GET: Admins/DoiTuongs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admins/DoiTuongs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DoiTuongId,SoThe,MienGiam")] DoiTuong doiTuong)
        {
            if (ModelState.IsValid)
            {
                _context.Add(doiTuong);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(doiTuong);
        }

        // GET: Admins/DoiTuongs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doiTuong = await _context.DoiTuongs.FindAsync(id);
            if (doiTuong == null)
            {
                return NotFound();
            }
            return View(doiTuong);
        }

        // POST: Admins/DoiTuongs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DoiTuongId,SoThe,MienGiam")] DoiTuong doiTuong)
        {
            if (id != doiTuong.DoiTuongId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doiTuong);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoiTuongExists(doiTuong.DoiTuongId))
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
            return View(doiTuong);
        }

        // GET: Admins/DoiTuongs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doiTuong = await _context.DoiTuongs
                .FirstOrDefaultAsync(m => m.DoiTuongId == id);
            if (doiTuong == null)
            {
                return NotFound();
            }

            return View(doiTuong);
        }

        // POST: Admins/DoiTuongs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var doiTuong = await _context.DoiTuongs.FindAsync(id);
            if (doiTuong != null)
            {
                _context.DoiTuongs.Remove(doiTuong);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoiTuongExists(int id)
        {
            return _context.DoiTuongs.Any(e => e.DoiTuongId == id);
        }
    }
}
