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
        public async Task<IActionResult> Index(string searchString, int page = 1, int pageSize = 5)
        {
            var chitietphongsQuery = _context.ChiTietPhongs
                .Include(c => c.BenhNhan)
                .Include(c => c.Phong)
                .Include(c => c.Giuong) // Thêm Include cho Giuong
                .AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                chitietphongsQuery = chitietphongsQuery
                    .Where(a => a.BenhNhan != null && a.BenhNhan.Cccd.Contains(searchString));
            }

            int totalRecords = await chitietphongsQuery.CountAsync();
            var ChiTietPhongs = await chitietphongsQuery.OrderBy(a => a.ChiTietPhongId)
                                          .Skip((page - 1) * pageSize)
                                          .Take(pageSize)
                                          .ToListAsync();
            TempData["CurrentPage"] = page;
            ViewData["CurrentPage"] = page;
            ViewData["TotalPages"] = (int)Math.Ceiling((double)totalRecords / pageSize);

            return View(ChiTietPhongs);
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
                .Include(c => c.Giuong)

                .FirstOrDefaultAsync(m => m.ChiTietPhongId == id);
            if (chiTietPhong == null)
            {
                return NotFound();
            }

            return PartialView("_DetailsPartial", chiTietPhong);
        }

        // GET: Admins/ChiTietPhongs/Create
        public IActionResult Create(int? id)
        {
            // Lấy danh sách các lựa chọn cho các dropdown
            ViewData["BenhNhanId"] = new SelectList(_context.BenhNhans, "BenhNhanId", "HoTen");
            ViewData["GiuongId"] = new SelectList(_context.Giuongs, "GiuongId", "SoGiuong");

            // Lấy danh sách ID phòng và giá phòng
            var danhSachGiaPhong = _context.Phongs.ToDictionary(p => p.PhongId, p => p.TienPhongNgay);
            ViewBag.GiaPhongJson = System.Text.Json.JsonSerializer.Serialize(danhSachGiaPhong);

            if (id.HasValue)
            {
                var benhNhan = _context.BenhNhans.FirstOrDefault(b => b.BenhNhanId == id);
                if (benhNhan == null) return NotFound();

                var chiTietPhong = new ChiTietPhong
                {
                    BenhNhanId = benhNhan.BenhNhanId,
                    Cccd = benhNhan.Cccd,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                };

                // Truyền tên bệnh nhân vào ViewData
                ViewData["BenhNhanHoTen"] = benhNhan.HoTen;

                // Lấy thông tin khoa của bệnh nhân và truyền vào ViewData
                var khoa = _context.Khoas.FirstOrDefault(k => k.KhoaId == benhNhan.KhoaId);
                if (khoa != null)
                {
                    ViewData["KhoaTen"] = khoa.TenKhoa;

                    // Lọc các phòng thuộc khoa này
                    var danhSachPhongTheoKhoa = _context.Phongs.Where(p => p.KhoaId == khoa.KhoaId).ToList();
                    ViewData["PhongId"] = new SelectList(danhSachPhongTheoKhoa, "PhongId", "SoPhong");
                }

                return View(chiTietPhong);
            }

            return View();
        }



        // POST: Admins/ChiTietPhongs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ChiTietPhongId,BenhNhanId,PhongId,GiuongId,NgayBatDau,NgayKetThuc,CreatedDate,UpdatedDate")] ChiTietPhong chiTietPhong)
        {
            if (ModelState.IsValid)
            {
                chiTietPhong.TienPhong = 0;
                _context.Add(chiTietPhong);

                // Cập nhật trạng thái giường thành "Đã sử dụng"
                var giuong = await _context.Giuongs.FindAsync(chiTietPhong.GiuongId);
                if (giuong != null)
                {
                    giuong.TrangThai = "Đã sử dụng";
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(chiTietPhong);
        }


        // GET: Admins/ChiTietPhongs/Edit/5
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
            ViewData["GiuongId"] = new SelectList(_context.Giuongs, "GiuongId", "SoGiuong", chiTietPhong.GiuongId);
            // Lấy danh sách giá phòng
            var danhSachGiaPhong = _context.Phongs.ToDictionary(p => p.PhongId.ToString(), p => p.TienPhongNgay);
            ViewBag.GiaPhongJson = System.Text.Json.JsonSerializer.Serialize(danhSachGiaPhong);



            return PartialView("_EditPartial", chiTietPhong);
        }


        // POST: Admins/ChiTietPhongs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ChiTietPhongId,BenhNhanId,PhongId,GiuongId,NgayBatDau,NgayKetThuc,TienPhong,CreatedDate,UpdatedDate")] ChiTietPhong chiTietPhong)
        {
            if (id != chiTietPhong.ChiTietPhongId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var existingChitietphong = await _context.ChiTietPhongs
                        .AsNoTracking()
                        .FirstOrDefaultAsync(b => b.ChiTietPhongId == id);

                    if (existingChitietphong == null)
                    {
                        return NotFound();
                    }
                    _context.Update(chiTietPhong);

                    // Nếu bệnh nhân xuất viện, giải phóng giường
                    if (chiTietPhong.NgayKetThuc.HasValue)
                    {
                        var giuong = await _context.Giuongs.FindAsync(chiTietPhong.GiuongId);
                        if (giuong != null)
                        {
                            giuong.TrangThai = "Trống";
                            _context.Giuongs.Update(giuong);
                        }
                    }

                    // Giữ nguyên CreatedDate và cập nhật UpdatedDate
                    chiTietPhong.CreatedDate = existingChitietphong.CreatedDate;
                    chiTietPhong.UpdatedDate = DateTime.Now;

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
                int currentPage = TempData["CurrentPage"] != null ? (int)TempData["CurrentPage"] : 1;
                return RedirectToAction(nameof(Index), new { page = currentPage });
            }

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

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chiTietPhong = await _context.ChiTietPhongs
                .Include(c => c.Giuong)
                .FirstOrDefaultAsync(m => m.ChiTietPhongId == id);

            if (chiTietPhong == null)
            {
                return Json(new { success = false, message = "Không tìm thấy dữ liệu!" });
            }

            // Cập nhật trạng thái giường về trống
            if (chiTietPhong.Giuong != null)
            {
                chiTietPhong.Giuong.TrangThai = "Trống"; // Nếu TrangThai là string
                _context.Update(chiTietPhong.Giuong);
            }

            // Xóa chi tiết phòng
            _context.ChiTietPhongs.Remove(chiTietPhong);
            await _context.SaveChangesAsync();

            return Json(new { success = true, message = "Xóa thành công!" });
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
                    khoaId = b.KhoaId, // Trả về ID của khoa
                    khoa = b.Khoa != null ? b.Khoa.TenKhoa : "Chưa cập nhật"
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

        [HttpGet]
        public async Task<IActionResult> GetPhongByKhoa(int khoaId)
        {
            var danhSachPhong = await _context.Phongs
                .Where(p => p.KhoaId == khoaId)
                .Select(p => new { p.PhongId, p.SoPhong })
                .ToListAsync();

            return Json(danhSachPhong);
        }
        [HttpGet("GetGiaPhong/{phongId}")]
        public async Task<IActionResult> GetGiaPhong(int phongId)
        {
            var phong = await _context.Phongs.FindAsync(phongId);
            if (phong == null)
            {
                return NotFound();
            }
            return Ok(phong.TienPhongNgay); // Trả về giá phòng theo ngày
        }
        [HttpGet]
        public IActionResult GetGiuongByPhong(int phongId)
        {
            var danhSachGiuong = _context.Giuongs
                                        .Where(g => g.PhongId == phongId && g.TrangThai == "Trống") // Chỉ lấy giường trống
                                        .Select(g => new { giuongId = g.GiuongId, soGiuong = g.SoGiuong })
                                        .ToList();
            return Json(danhSachGiuong);
        }



    }
}
