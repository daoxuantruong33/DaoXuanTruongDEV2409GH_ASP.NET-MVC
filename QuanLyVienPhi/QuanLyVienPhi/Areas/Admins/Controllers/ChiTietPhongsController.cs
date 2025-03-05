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

    public class ChiTietPhongsController : BaseController
    {
        private readonly QuanLyVienPhiContext _context;

        public ChiTietPhongsController(QuanLyVienPhiContext context)
        {
            _context = context;
        }

        // GET: Admins/ChiTietPhongs
        public async Task<IActionResult> Index()
        {
            var quanLyVienPhiContext = _context.ChiTietPhongs.Include(c => c.BenhNhan).Include(c => c.Phong);
            return View(await quanLyVienPhiContext.ToListAsync());
        }

        // GET: Admins/ChiTietPhongs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chiTietPhong = await _context.ChiTietPhongs
                .Include(c => c.BenhNhan)
                .Include(c => c.Phong)
                .FirstOrDefaultAsync(m => m.ChiTietPhongId == id);
            if (chiTietPhong == null)
            {
                return NotFound();
            }

            return View(chiTietPhong);
        }

        // GET: Admins/ChiTietPhongs/Create
        public IActionResult Create()
        {
            ViewData["BenhNhanId"] = new SelectList(_context.BenhNhans, "BenhNhanId", "HoTen");
            ViewData["PhongId"] = new SelectList(_context.Phongs, "PhongId", "SoPhong");

            // Lấy danh sách ID phòng và giá phòng
            var danhSachGiaPhong = _context.Phongs.ToDictionary(p => p.PhongId, p => p.TienPhongNgay);
            ViewBag.GiaPhongJson = System.Text.Json.JsonSerializer.Serialize(danhSachGiaPhong);

            return View();
        }


        // POST: Admins/ChiTietPhongs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ChiTietPhongId,BenhNhanId,PhongId,NgayBatDau,NgayKetThuc,TienPhong")] ChiTietPhong chiTietPhong)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chiTietPhong);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BenhNhanId"] = new SelectList(_context.BenhNhans, "BenhNhanId", "HoTen", chiTietPhong.BenhNhanId);
            ViewData["PhongId"] = new SelectList(_context.Phongs, "PhongId", "SoPhong", chiTietPhong.PhongId);
            return View(chiTietPhong);
        }

        // GET: Admins/ChiTietPhongs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chiTietPhong = await _context.ChiTietPhongs.FindAsync(id);
            if (chiTietPhong == null)
            {
                return NotFound();
            }
            ViewData["BenhNhanId"] = new SelectList(_context.BenhNhans, "BenhNhanId", "HoTen", chiTietPhong.BenhNhanId);
            ViewData["PhongId"] = new SelectList(_context.Phongs, "PhongId", "SoPhong", chiTietPhong.PhongId);
            return View(chiTietPhong);
        }

        // POST: Admins/ChiTietPhongs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ChiTietPhongId,BenhNhanId,PhongId,NgayBatDau,NgayKetThuc,TienPhong")] ChiTietPhong chiTietPhong)
        {
            if (id != chiTietPhong.ChiTietPhongId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chiTietPhong);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChiTietPhongExists(chiTietPhong.ChiTietPhongId))
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
            ViewData["BenhNhanId"] = new SelectList(_context.BenhNhans, "BenhNhanId", "HoTen", chiTietPhong.BenhNhanId);
            ViewData["PhongId"] = new SelectList(_context.Phongs, "PhongId", "SoPhong", chiTietPhong.PhongId);
            return View(chiTietPhong);
        }

        // GET: Admins/ChiTietPhongs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chiTietPhong = await _context.ChiTietPhongs
                .Include(c => c.BenhNhan)
                .Include(c => c.Phong)
                .FirstOrDefaultAsync(m => m.ChiTietPhongId == id);
            if (chiTietPhong == null)
            {
                return NotFound();
            }

            return View(chiTietPhong);
        }

        // POST: Admins/ChiTietPhongs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chiTietPhong = await _context.ChiTietPhongs.FindAsync(id);
            if (chiTietPhong != null)
            {
                _context.ChiTietPhongs.Remove(chiTietPhong);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChiTietPhongExists(int id)
        {
            return _context.ChiTietPhongs.Any(e => e.ChiTietPhongId == id);
        }


        [HttpGet]
        public async Task<IActionResult> GetThongTinBenhNhan(int benhNhanId)
        {
            var benhNhan = await _context.BenhNhans
                .Include(b => b.Khoa) // Load thông tin Khoa
                .Where(b => b.BenhNhanId == benhNhanId)
                .Select(b => new
                {
                    cccd = b.Cccd, // Lấy CCCD của bệnh nhân
                    ngayNhapVien = b.NgayNhapVien.ToString("yyyy-MM-dd"),
                    khoa = b.Khoa != null ? b.Khoa.TenKhoa : "Chưa cập nhật",
                    phongId = b.PhongId // Lấy Phòng hiện tại của bệnh nhân
                })
                .FirstOrDefaultAsync();

            if (benhNhan == null)
            {
                return NotFound();
            }

            return Json(benhNhan);
        }


        [HttpGet]
        public async Task<IActionResult> GetPhongByBenhNhan(int benhNhanId)
        {
            var benhNhan = await _context.BenhNhans
                .Where(b => b.BenhNhanId == benhNhanId)
                .Select(b => new { PhongId = b.PhongId })
                .FirstOrDefaultAsync();

            if (benhNhan == null)
            {
                return NotFound();
            }

            return Json(benhNhan);
        }


    }
}
