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
            return View(await _context.BacSis.ToListAsync());
        }

        // GET: Admins/BacSis/Details/5
        public async Task<IActionResult> Details(int? id)
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

        // GET: Admins/BacSis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admins/BacSis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BacSiId,HoTen,ChuyenKhoa,DienThoai,Email")] BacSi bacSi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bacSi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
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
            return View(bacSi);
        }

        // POST: Admins/BacSis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BacSiId,HoTen,ChuyenKhoa,DienThoai,Email")] BacSi bacSi)
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
