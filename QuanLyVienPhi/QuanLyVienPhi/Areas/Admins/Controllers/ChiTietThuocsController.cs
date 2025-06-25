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
    public class ChiTietThuocsController : BaseController
    {
        private readonly QuanLyVienPhiContext _context;

        public ChiTietThuocsController(QuanLyVienPhiContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string searchString, int page = 1, int pageSize = 5)
        {
            var chitietthuocsQuery = _context.ChiTietThuocs
                .Include(c => c.BenhNhan)
                .Include(c => c.Thuoc)
                .AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                chitietthuocsQuery = chitietthuocsQuery.Where(a => a.Cccd.Contains(searchString));
            }

            int totalRecords = await chitietthuocsQuery.CountAsync();
            var ChiTietThuocs = await chitietthuocsQuery.OrderBy(a => a.ChiTietThuocId)
                                          .Skip((page - 1) * pageSize)
                                          .Take(pageSize)
                                          .ToListAsync();
            TempData["CurrentPage"] = page;
            ViewData["CurrentPage"] = page;
            ViewData["TotalPages"] = (int)Math.Ceiling((double)totalRecords / pageSize);
            ViewData["SearchString"] = searchString;

            return View(ChiTietThuocs);
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

            return PartialView("_DetailsPartial", chiTietThuoc);
        }

        // GET: Admins/ChiTietThuocs/Create
        public IActionResult Create(int? id)
        {
            ViewData["ThuocId"] = new SelectList(_context.Thuocs, "ThuocId", "TenThuoc");

            if (id.HasValue)
            {
                var benhNhan = _context.BenhNhans.FirstOrDefault(b => b.BenhNhanId == id);
                if (benhNhan == null) return NotFound();

                var chiTietThuoc = new ChiTietThuoc
                {
                    BenhNhanId = benhNhan.BenhNhanId,
                    Cccd = benhNhan.Cccd,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                };

                ViewData["BenhNhanHoTen"] = benhNhan.HoTen;

                return View(chiTietThuoc);
            }

            ViewData["BenhNhanId"] = new SelectList(_context.BenhNhans, "BenhNhanId", "HoTen");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ChiTietThuocId,BenhNhanId,ThuocId,SoLuong,TienThuoc,CreatedDate,UpdatedDate")] ChiTietThuoc chiTietThuoc)
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

            ViewData["BenhNhanId"] = new SelectList(_context.BenhNhans, "BenhNhanId", "HoTen", chiTietThuoc.BenhNhanId);
            ViewData["ThuocId"] = new SelectList(_context.Thuocs, "ThuocId", "TenThuoc", chiTietThuoc.ThuocId);
            return View(chiTietThuoc);
        }

        // GET: Admins/ChiTietThuocs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chiTietThuoc = await _context.ChiTietThuocs
                .Include(ct => ct.BenhNhan) // Bao gồm thông tin từ bảng BenhNhan
                .FirstOrDefaultAsync(ct => ct.ChiTietThuocId == id);

            if (chiTietThuoc == null)
            {
                return NotFound();
            }

            // Gán CCCD từ BenhNhan nếu có
            if (chiTietThuoc.BenhNhan != null)
            {
                chiTietThuoc.Cccd = chiTietThuoc.BenhNhan.Cccd;
            }

            ViewData["BenhNhanId"] = new SelectList(_context.BenhNhans, "BenhNhanId", "HoTen", chiTietThuoc.BenhNhanId);
            ViewData["ThuocId"] = new SelectList(_context.Thuocs, "ThuocId", "TenThuoc", chiTietThuoc.ThuocId);

            return PartialView("_EditPartial", chiTietThuoc);
        }


        // POST: Admins/ChiTietThuocs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ChiTietThuocId,BenhNhanId,Cccd,ThuocId,SoLuong,TienThuoc,CreatedDate,UpdatedDate")] ChiTietThuoc chiTietThuoc)
        {
            if (id != chiTietThuoc.ChiTietThuocId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var existingChiTietThuocs = await _context.ChiTietThuocs
                        .AsNoTracking()
                        .FirstOrDefaultAsync(b => b.ChiTietThuocId == id);

                    if (existingChiTietThuocs == null)
                    {
                        return NotFound();
                    }
                    _context.Update(chiTietThuoc);

                    // Lấy giá thuốc để tính tiền thuốc
                    var thuoc = await _context.Thuocs.FindAsync(chiTietThuoc.ThuocId);
                    if (thuoc != null)
                    {
                        chiTietThuoc.TienThuoc = thuoc.GiaTien * chiTietThuoc.SoLuong;
                        Console.WriteLine($"Debug: GiaTien = {thuoc.GiaTien}, SoLuong = {chiTietThuoc.SoLuong}, TienThuoc = {chiTietThuoc.TienThuoc}");
                    }

                    // Giữ nguyên CreatedDate và cập nhật UpdatedDate
                    chiTietThuoc.CreatedDate = existingChiTietThuocs.CreatedDate;
                    chiTietThuoc.UpdatedDate = DateTime.Now;

                    // Cập nhật dữ liệu vào database
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
                int currentPage = TempData["CurrentPage"] != null ? (int)TempData["CurrentPage"] : 1;
                return RedirectToAction(nameof(Index), new { page = currentPage });
            }
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
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var chitietthuoc = _context.ChiTietThuocs.Find(id);
            if (chitietthuoc != null)
            {
                _context.ChiTietThuocs.Remove(chitietthuoc);
                _context.SaveChanges();
            }
            int currentPage = TempData["CurrentPage"] != null ? (int)TempData["CurrentPage"] : 1;
            return RedirectToAction(nameof(Index), new { page = currentPage });
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
        [HttpGet]
        public async Task<IActionResult> GetCCCD(int id)
        {
            var benhNhan = await _context.BenhNhans.FindAsync(id);
            if (benhNhan != null)
            {
                return Json(benhNhan.Cccd);
            }
            return NotFound();
        }

    }
}
