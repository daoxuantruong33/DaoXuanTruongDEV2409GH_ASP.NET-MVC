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
    public class BacSisController : BaseController
    {
        private readonly QuanLyVienPhiContext _context;

        public BacSisController(QuanLyVienPhiContext context)
        {
            _context = context;
        }

        // GET: Admins/BacSis
        public async Task<IActionResult> Index()
        {
            var bacSis = _context.BacSis.Include(b => b.Khoa);
            return View(await bacSis.ToListAsync());
        }


        // GET: Admins/BenhNhans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bacsi = await _context.BacSis
                .Include(b => b.Khoa)
                .FirstOrDefaultAsync(m => m.BacSiId == id);
            if (bacsi == null)
            {
                return NotFound();
            }

            return View(bacsi);
        }


        // GET: Admins/BacSis/Create
        public IActionResult Create()
        {
            ViewData["KhoaId"] = new SelectList(_context.Khoas, "KhoaId", "TenKhoa");

            return View();
        }

        // POST: Admins/BacSis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BacSiId,HoTen,KhoaId,DienThoai,Email")] BacSi bacSi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bacSi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KhoaId"] = new SelectList(_context.Khoas, "KhoaId", "KhoaId", bacSi.KhoaId);

            return View(bacSi);
        }

        // GET: Admins/BacSis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bacSi = await _context.BacSis.FindAsync(id);
            if (bacSi == null)
            {
                return NotFound();
            }
            ViewData["KhoaId"] = new SelectList(_context.Khoas, "KhoaId", "TenKhoa", bacSi.KhoaId);

            return View(bacSi);
        }

        // POST: Admins/BacSis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BacSiId,HoTen,KhoaId,DienThoai,Email")] BacSi bacSi)
        {
            if (id != bacSi.BacSiId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bacSi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BacSiExists(bacSi.BacSiId))
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
            ViewData["KhoaId"] = new SelectList(_context.Khoas, "KhoaId", "KhoaId", bacSi.KhoaId);
            return View(bacSi);
        }

        // GET: Admins/BacSis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bacSi = await _context.BacSis
                .FirstOrDefaultAsync(m => m.BacSiId == id);
            if (bacSi == null)
            {
                return NotFound();
            }

            return View(bacSi);
        }

        // POST: Admins/BacSis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bacSi = await _context.BacSis.FindAsync(id);
            if (bacSi != null)
            {
                _context.BacSis.Remove(bacSi);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BacSiExists(int id)
        {
            return _context.BacSis.Any(e => e.BacSiId == id);
        }
    }
}
