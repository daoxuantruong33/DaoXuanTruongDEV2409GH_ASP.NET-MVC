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
    public class ThuNgansController : BaseController
    {
        private readonly QuanLyVienPhiContext _context;

        public ThuNgansController(QuanLyVienPhiContext context)
        {
            _context = context;
        }

        // GET: Admins/ThuNgans
        public async Task<IActionResult> Index()
        {
            return View(await _context.ThuNgans.ToListAsync());
        }

        // GET: Admins/ThuNgans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thuNgan = await _context.ThuNgans
                .FirstOrDefaultAsync(m => m.ThuNganId == id);
            if (thuNgan == null)
            {
                return NotFound();
            }

            return View(thuNgan);
        }

        // GET: Admins/ThuNgans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admins/ThuNgans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ThuNganId,HoTen,DienThoai,Email")] ThuNgan thuNgan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(thuNgan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(thuNgan);
        }

        // GET: Admins/ThuNgans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thuNgan = await _context.ThuNgans.FindAsync(id);
            if (thuNgan == null)
            {
                return NotFound();
            }
            return View(thuNgan);
        }

        // POST: Admins/ThuNgans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ThuNganId,HoTen,DienThoai,Email")] ThuNgan thuNgan)
        {
            if (id != thuNgan.ThuNganId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(thuNgan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ThuNganExists(thuNgan.ThuNganId))
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
            return View(thuNgan);
        }

        // GET: Admins/ThuNgans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thuNgan = await _context.ThuNgans
                .FirstOrDefaultAsync(m => m.ThuNganId == id);
            if (thuNgan == null)
            {
                return NotFound();
            }

            return View(thuNgan);
        }

        // POST: Admins/ThuNgans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var thuNgan = await _context.ThuNgans.FindAsync(id);
            if (thuNgan != null)
            {
                _context.ThuNgans.Remove(thuNgan);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ThuNganExists(int id)
        {
            return _context.ThuNgans.Any(e => e.ThuNganId == id);
        }
    }
}
