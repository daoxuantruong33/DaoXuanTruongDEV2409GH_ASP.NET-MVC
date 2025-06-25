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
        public async Task<IActionResult> Index(string searchString , int page = 1, int pageSize = 5)
        {
            var bhytssQuery = _context.Bhyts.Include(b => b.BenhNhan).Include(b => b.DoiTuong).AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                bhytssQuery = bhytssQuery.Where(a => a.Cccd.Contains(searchString));
            }

            int totalRecords = await bhytssQuery.CountAsync();
            var bhyts = await bhytssQuery.OrderBy(a => a.BhytId)
                                          .Skip((page - 1) * pageSize)
                                          .Take(pageSize)
                                          .ToListAsync();
            TempData["CurrentPage"] = page;
            ViewData["CurrentPage"] = page;
            ViewData["TotalPages"] = (int)Math.Ceiling((double)totalRecords / pageSize);

            return View(bhyts);
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

            return PartialView("_DetailsPartial", bhyt);
        }

        public IActionResult Create(int? id)
        {
            ViewData["BhytId"] = new SelectList(_context.Bhyts, "BhytId", "SoTheBhyt");

            if (id.HasValue)
            {
                var benhNhan = _context.BenhNhans.FirstOrDefault(b => b.BenhNhanId == id);
                if (benhNhan == null) return NotFound();

                var bhyt = new Bhyt
                {
                    BenhNhanId = benhNhan.BenhNhanId,
                    Cccd = benhNhan.Cccd,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                };

                ViewData["BenhNhanHoTen"] = benhNhan.HoTen;

                return View(bhyt);
            }

            ViewData["BenhNhanId"] = new SelectList(_context.BenhNhans, "BenhNhanId", "HoTen");
            return View();
        }


        // POST: Admins/Bhyts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BhytId,BenhNhanId,Cccd,DoiTuongId,SoTheBhyt,MienGiam,CreatedDate,UpdatedDate")] Bhyt bhyt)
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
            ViewData["BenhNhanId"] = new SelectList(_context.BenhNhans, "BenhNhanId", "HoTen", bhyt.BenhNhanId);
            ViewData["DoiTuongId"] = new SelectList(_context.DoiTuongs, "DoiTuongId", "DoiTuongId", bhyt.DoiTuongId);
            return PartialView("_EditPartial",bhyt);
        }

        // POST: Admins/Bhyts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BhytId,BenhNhanId,Cccd,DoiTuongId,SoTheBhyt,MienGiam,CreatedDate,UpdatedDate")] Bhyt bhyt)
        {
            if (id != bhyt.BhytId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var existingBhyts = await _context.Bhyts
                        .AsNoTracking()
                        .FirstOrDefaultAsync(b => b.BhytId == id);

                    if (existingBhyts == null)
                    {
                        return NotFound();
                    }

                    bhyt.CreatedDate = existingBhyts.CreatedDate; // Giữ nguyên ngày tạo
                    bhyt.UpdatedDate = DateTime.Now; // Cập nhật ngày sửa đổi

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
                int currentPage = TempData["CurrentPage"] != null ? (int)TempData["CurrentPage"] : 1;
                return RedirectToAction(nameof(Index), new { page = currentPage });
            }

            ViewData["BenhNhanId"] = new SelectList(_context.BenhNhans, "BenhNhanId", "HoTen", bhyt.BenhNhanId);
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
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var bhyt = _context.Bhyts.Find(id);
            if (bhyt != null)
            {
                _context.Bhyts.Remove(bhyt);
                _context.SaveChanges();
            }
            int currentPage = TempData["CurrentPage"] != null ? (int)TempData["CurrentPage"] : 1;
            return RedirectToAction(nameof(Index), new { page = currentPage });
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
