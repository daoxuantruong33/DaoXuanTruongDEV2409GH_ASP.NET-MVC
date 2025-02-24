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
    public class ThanhToansController : Controller
    {
        private readonly QuanLyVienPhiContext _context;

        public ThanhToansController(QuanLyVienPhiContext context)
        {
            _context = context;
        }

        // GET: Admins/ThanhToans
        public async Task<IActionResult> Index()
        {
            var quanLyVienPhiContext = _context.ThanhToans.Include(t => t.HoaDon).Include(t => t.ThuNgan);
            return View(await quanLyVienPhiContext.ToListAsync());
        }

        // GET: Admins/ThanhToans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thanhToan = await _context.ThanhToans
                .Include(t => t.HoaDon)
                .Include(t => t.ThuNgan)
                .FirstOrDefaultAsync(m => m.ThanhToanId == id);
            if (thanhToan == null)
            {
                return NotFound();
            }

            return View(thanhToan);
        }

        // GET: Admins/ThanhToans/Create
        public IActionResult Create()
        {
            ViewData["HoaDonId"] = new SelectList(_context.HoaDons, "HoaDonId", "HoaDonId");
            ViewData["ThuNganId"] = new SelectList(_context.ThuNgans, "ThuNganId", "ThuNganId");
            return View();
        }

        // POST: Admins/ThanhToans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ThanhToanId,HoaDonId,HinhThuc,NgayThanhToan,SoTien,ThuNganId")] ThanhToan thanhToan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(thanhToan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HoaDonId"] = new SelectList(_context.HoaDons, "HoaDonId", "HoaDonId", thanhToan.HoaDonId);
            ViewData["ThuNganId"] = new SelectList(_context.ThuNgans, "ThuNganId", "ThuNganId", thanhToan.ThuNganId);
            return View(thanhToan);
        }

        // GET: Admins/ThanhToans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thanhToan = await _context.ThanhToans.FindAsync(id);
            if (thanhToan == null)
            {
                return NotFound();
            }
            ViewData["HoaDonId"] = new SelectList(_context.HoaDons, "HoaDonId", "HoaDonId", thanhToan.HoaDonId);
            ViewData["ThuNganId"] = new SelectList(_context.ThuNgans, "ThuNganId", "ThuNganId", thanhToan.ThuNganId);
            return View(thanhToan);
        }

        // POST: Admins/ThanhToans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ThanhToanId,HoaDonId,HinhThuc,NgayThanhToan,SoTien,ThuNganId")] ThanhToan thanhToan)
        {
            if (id != thanhToan.ThanhToanId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(thanhToan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ThanhToanExists(thanhToan.ThanhToanId))
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
            ViewData["HoaDonId"] = new SelectList(_context.HoaDons, "HoaDonId", "HoaDonId", thanhToan.HoaDonId);
            ViewData["ThuNganId"] = new SelectList(_context.ThuNgans, "ThuNganId", "ThuNganId", thanhToan.ThuNganId);
            return View(thanhToan);
        }

        // GET: Admins/ThanhToans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thanhToan = await _context.ThanhToans
                .Include(t => t.HoaDon)
                .Include(t => t.ThuNgan)
                .FirstOrDefaultAsync(m => m.ThanhToanId == id);
            if (thanhToan == null)
            {
                return NotFound();
            }

            return View(thanhToan);
        }

        // POST: Admins/ThanhToans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var thanhToan = await _context.ThanhToans.FindAsync(id);
            if (thanhToan != null)
            {
                _context.ThanhToans.Remove(thanhToan);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ThanhToanExists(int id)
        {
            return _context.ThanhToans.Any(e => e.ThanhToanId == id);
        }
    }
}
