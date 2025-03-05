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
    public class BhytsController : BaseController
    {
        private readonly QuanLyVienPhiContext _context;

        public BhytsController(QuanLyVienPhiContext context)
        {
            _context = context;
        }

        // GET: Admins/Bhyts
        public async Task<IActionResult> Index()
        {
            var quanLyVienPhiContext = _context.Bhyts.Include(b => b.BenhNhan).Include(b => b.DoiTuong);
            return View(await quanLyVienPhiContext.ToListAsync());
        }

        // GET: Admins/Bhyts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bhyt = await _context.Bhyts
                .Include(b => b.BenhNhan)
                .Include(b => b.DoiTuong)
                .FirstOrDefaultAsync(m => m.BhytId == id);
            if (bhyt == null)
            {
                return NotFound();
            }

            return View(bhyt);
        }

        public IActionResult Create()
        {
            ViewData["BenhNhanId"] = new SelectList(_context.BenhNhans, "BenhNhanId", "HoTen"); // Chọn theo tên
            ViewData["DoiTuongId"] = new SelectList(_context.DoiTuongs, "DoiTuongId", "DoiTuongId");
            return View();
        }


        // POST: Admins/Bhyts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BhytId,BenhNhanId,Cccd,DoiTuongId,SoTheBhyt,MienGiam")] Bhyt bhyt)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bhyt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BenhNhanId"] = new SelectList(_context.BenhNhans, "BenhNhanId", "BenhNhanId", bhyt.BenhNhanId);
            ViewData["DoiTuongId"] = new SelectList(_context.DoiTuongs, "DoiTuongId", "DoiTuongId", bhyt.DoiTuongId);
            return View(bhyt);
        }

        // GET: Admins/Bhyts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bhyt = await _context.Bhyts.FindAsync(id);
            if (bhyt == null)
            {
                return NotFound();
            }
            ViewData["BenhNhanId"] = new SelectList(_context.BenhNhans, "BenhNhanId", "BenhNhanId", bhyt.BenhNhanId);
            ViewData["DoiTuongId"] = new SelectList(_context.DoiTuongs, "DoiTuongId", "DoiTuongId", bhyt.DoiTuongId);
            return View(bhyt);
        }

        // POST: Admins/Bhyts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BhytId,BenhNhanId,Cccd,DoiTuongId,SoTheBhyt,MienGiam")] Bhyt bhyt)
        {
            if (id != bhyt.BhytId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bhyt);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BhytExists(bhyt.BhytId))
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
            ViewData["BenhNhanId"] = new SelectList(_context.BenhNhans, "BenhNhanId", "BenhNhanId", bhyt.BenhNhanId);
            ViewData["DoiTuongId"] = new SelectList(_context.DoiTuongs, "DoiTuongId", "DoiTuongId", bhyt.DoiTuongId);
            return View(bhyt);
        }

        // GET: Admins/Bhyts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bhyt = await _context.Bhyts
                .Include(b => b.BenhNhan)
                .Include(b => b.DoiTuong)
                .FirstOrDefaultAsync(m => m.BhytId == id);
            if (bhyt == null)
            {
                return NotFound();
            }

            return View(bhyt);
        }

        // POST: Admins/Bhyts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bhyt = await _context.Bhyts.FindAsync(id);
            if (bhyt != null)
            {
                _context.Bhyts.Remove(bhyt);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BhytExists(int id)
        {
            return _context.Bhyts.Any(e => e.BhytId == id);
        }

        [HttpGet]
        public JsonResult GetMienGiamBySoThe(string soTheBhyt)
        {
            if (string.IsNullOrEmpty(soTheBhyt))
            {
                return Json(0);
            }

            // Lấy số đầu tiên của thẻ BHYT
            char firstDigit = soTheBhyt[0];

            // Tìm đối tượng có mã bắt đầu bằng số đầu tiên
            var doiTuong = _context.DoiTuongs.FirstOrDefault(d => d.SoThe.StartsWith(firstDigit.ToString()));

            if (doiTuong != null)
            {
                return Json(doiTuong.MienGiam);
            }

            return Json(0);
        }
        [HttpGet]
        public JsonResult GetCccdByBenhNhanId(int benhNhanId)
        {
            var benhNhan = _context.BenhNhans.FirstOrDefault(b => b.BenhNhanId == benhNhanId);

            if (benhNhan != null)
            {
                return Json(benhNhan.Cccd);  // Giả sử cột CCCD trong bảng BenhNhan là `Cccd`
            }

            return Json("");
        }

    }
}
