using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using QuanLyVienPhi.Models;
using QuanLyVienPhi.Models.API;
using System.Drawing;
using RestSharp;
using System.Drawing.Imaging;
namespace QuanLyVienPhi.Areas.Admins.Controllers
{
    public class BenhNhansController : BaseController
    {
        private readonly QuanLyVienPhiContext _context;
        private Bank listBankData;
        private string URLBank = "https://api.vietqr.io/v2/banks";
        private string URLQRCode = "https://api.vietqr.io/v2/generate";


        public BenhNhansController(QuanLyVienPhiContext context)
        {
            _context = context;
        }

        // GET: Admins/BenhNhans
        public async Task<IActionResult> Index(string searchString, int page = 1, int pageSize = 5)
        {
            GetListBank();

            var benhNhansQuery = _context.BenhNhans
                .Include(b => b.BacSi)
                .Include(b => b.Khoa)
                .Include(b => b.Phong)
                .Include(b => b.ChiTietDichVus)
                .Include(b => b.ChiTietPhongs)
                .Include(b => b.ChiTietThuocs)
                .AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                benhNhansQuery = benhNhansQuery.Where(a => a.HoTen.Contains(searchString));
            }

            int totalRecords = await benhNhansQuery.CountAsync();
            var benhNhans = await benhNhansQuery
                .OrderBy(a => a.BenhNhanId)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            // Cập nhật lại Tiền Phòng, Tiền Thuốc, Tiền Dịch Vụ
            foreach (var benhNhan in benhNhans)
            {
                benhNhan.TienPhong = benhNhan.ChiTietPhongs.Sum(cp => cp.TienPhong);
                benhNhan.TienThuoc = benhNhan.ChiTietThuocs.Sum(ct => ct.TienThuoc);
                benhNhan.TienDichVu = benhNhan.ChiTietDichVus.Sum(ct => ct.GiaTien);

            }

            ViewData["CurrentPage"] = page;
            ViewData["TotalPages"] = (int)Math.Ceiling((double)totalRecords / pageSize);
            ViewData["SearchString"] = searchString;

            return View(benhNhans);
        }




        // GET: Admins/BenhNhans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var benhNhan = await _context.BenhNhans
     .Include(b => b.BacSi)
     .Include(b => b.Khoa)
     .Include(b => b.Phong)
     .Include(b => b.ChiTietPhongs)
         .ThenInclude(cp => cp.Phong) // Load thông tin phòng
     .Include(b => b.ChiTietPhongs)
         .ThenInclude(cp => cp.Giuong) // Load thông tin giường
     .FirstOrDefaultAsync(m => m.BenhNhanId == id);

            if (benhNhan == null)
            {
                return NotFound();
            }

            // Lấy ngày ra viện (Ngày kết thúc lớn nhất)
            benhNhan.NgayRaVien = benhNhan.ChiTietPhongs
                .OrderByDescending(cp => cp.NgayKetThuc)
                .Select(cp => cp.NgayKetThuc)
                .FirstOrDefault();

            // Lấy phòng gần nhất
            var phongMoiNhat = benhNhan.ChiTietPhongs
                .OrderByDescending(cp => cp.NgayKetThuc)
                .Select(cp => cp.Phong)
                .FirstOrDefault();

            // Lấy giường gần nhất
            var giuongMoiNhat = benhNhan.ChiTietPhongs
                .OrderByDescending(cp => cp.NgayKetThuc)
                .Select(cp => cp.Giuong)
                .FirstOrDefault();

            // Gán vào model
            benhNhan.Phong = phongMoiNhat;
            ViewBag.GiuongMoiNhat = giuongMoiNhat; // Gửi giường qua View

            return PartialView("_DetailsPartial", benhNhan);

        }


        // GET: Admins/BenhNhans/Create
        public IActionResult Create()
        {
            ViewData["BacSiId"] = new SelectList(_context.BacSis, "BacSiId", "HoTen");
            ViewData["KhoaId"] = new SelectList(_context.Khoas, "KhoaId", "TenKhoa");
            ViewData["PhongId"] = new SelectList(new List<Phong>(), "PhongId", "SoPhong"); // Ban đầu để trống
            ViewData["ThuNganId"] = new SelectList(_context.ThuNgans, "ThuNganId", "HoTen");

            return View();
        }

        // POST: Admins/BenhNhans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BenhNhanId,HoTen,NgaySinh,GioiTinh,DiaChi,DienThoai,Cccd,NgayNhapVien,NgayRaVien,BacSiId,YtaId,KhoaId,PhongId,ThuNganId,CreatedDate,UpdatedDate")] BenhNhan benhNhan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(benhNhan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BacSiId"] = new SelectList(_context.BacSis, "BacSiId", "BacSiId", benhNhan.BacSiId);
            ViewData["KhoaId"] = new SelectList(_context.Khoas, "KhoaId", "KhoaId", benhNhan.KhoaId);
            ViewData["PhongId"] = new SelectList(_context.Phongs, "PhongId", "PhongId", benhNhan.PhongId);
            ViewData["ThuNganId"] = new SelectList(_context.ThuNgans, "ThuNganId", "HoTen", benhNhan.ThuNganId);

            return View(benhNhan);
        }

        // GET: Admins/BenhNhans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var benhNhan = await _context.BenhNhans.FindAsync(id);
            if (benhNhan == null)
            {
                return NotFound();
            }
            ViewData["BacSiId"] = new SelectList(_context.BacSis, "BacSiId", "HoTen", benhNhan.BacSiId);
            ViewData["KhoaId"] = new SelectList(_context.Khoas, "KhoaId", "TenKhoa", benhNhan.KhoaId);
            ViewData["PhongId"] = new SelectList(_context.Phongs, "PhongId", "SoPhong", benhNhan.PhongId);
            return PartialView("_EditPartial", benhNhan);
        }

        // POST: Admins/BenhNhans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BenhNhanId,HoTen,NgaySinh,GioiTinh,DiaChi,DienThoai,Cccd,NgayNhapVien,NgayRaVien,BacSiId,YtaId,KhoaId,PhongId,TrangThaiThanhToan,CreatedDate,UpdatedDate")] BenhNhan benhNhan)
        {
            if (id != benhNhan.BenhNhanId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var existingBenhNhan = await _context.BenhNhans
                        .AsNoTracking()
                        .FirstOrDefaultAsync(b => b.BenhNhanId == id);

                    if (existingBenhNhan == null)
                    {
                        return NotFound();
                    }

                    // Kiểm tra giá trị trước khi cập nhật
                    Console.WriteLine($"ModelState.IsValid: {ModelState.IsValid}");
                    Console.WriteLine($"Giá trị nhận được từ form: {benhNhan.TrangThaiThanhToan}");


                    // Giữ nguyên CreatedDate và cập nhật UpdatedDate
                    benhNhan.CreatedDate = existingBenhNhan.CreatedDate;
                    benhNhan.UpdatedDate = DateTime.Now;

                    _context.Update(benhNhan);
                    await _context.SaveChangesAsync();

                    // Kiểm tra sau khi lưu
                    var checkAfterSave = await _context.BenhNhans.FindAsync(id);
                    Console.WriteLine($"Sau khi cập nhật: {checkAfterSave.TrangThaiThanhToan}");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BenhNhanExists(benhNhan.BenhNhanId))
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

            ViewData["BacSiId"] = new SelectList(_context.BacSis, "BacSiId", "HoTen", benhNhan.BacSiId);
            ViewData["KhoaId"] = new SelectList(_context.Khoas, "KhoaId", "TenKhoa", benhNhan.KhoaId);
            ViewData["PhongId"] = new SelectList(_context.Phongs, "PhongId", "SoPhong", benhNhan.PhongId);
            return View(benhNhan);
        }



        // GET: Admins/BenhNhans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var benhNhan = await _context.BenhNhans
                .Include(b => b.BacSi)
                .Include(b => b.Khoa)
                .Include(b => b.Phong)

                .FirstOrDefaultAsync(m => m.BenhNhanId == id);
            if (benhNhan == null)
            {
                return NotFound();
            }

            return View(benhNhan);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var benhnhan = _context.BenhNhans.Find(id);
            if (benhnhan != null)
            {
                _context.BenhNhans.Remove(benhnhan);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }


        private bool BenhNhanExists(int id)
        {
            return _context.BenhNhans.Any(e => e.BenhNhanId == id);
        }


        public IActionResult Invoice(int id)
        {
            var benhNhan = _context.BenhNhans
                .Include(b => b.BacSi)
                .Include(b => b.Khoa)
                .Include(b => b.Phong)
                .Include(b => b.ThuNgan)
                .Include(b => b.ChiTietDichVus)
                .Include(b => b.ChiTietPhongs)
                .Include(b => b.ChiTietThuocs) // Bao gồm thông tin ChiTietThuoc
                .ThenInclude(ct => ct.Thuoc) // Thêm Include để lấy thông tin thuốc
                .Include(b => b.Bhyts)
                .FirstOrDefault(b => b.BenhNhanId == id);

            if (benhNhan == null)
            {
                return NotFound();
            }

            // Cập nhật Tiền Phòng và Tiền Thuốc trước khi hiển thị hóa đơn
            benhNhan.TienDichVu = benhNhan.ChiTietDichVus.Sum(cp => cp.GiaTien);
            benhNhan.TienPhong = benhNhan.ChiTietPhongs.Sum(cp => cp.TienPhong);
            benhNhan.TienThuoc = benhNhan.ChiTietThuocs.Sum(cp => cp.TienThuoc);
            benhNhan.MienGiam = benhNhan.Bhyts.Sum(ct => ct.MienGiam);

            return View(benhNhan);
        }



        [HttpPost]
        public IActionResult ThanhToan(int id, string phuongThucThanhToan)
        {
            var benhNhan = _context.BenhNhans.Find(id);
            if (benhNhan == null)
            {
                return NotFound();
            }

            benhNhan.TrangThaiThanhToan = true;
            //benhNhan.PhuongThucThanhToan = phuongThucThanhToan; // Lưu phương thức thanh toán
            _context.SaveChanges();

            // Chuyển hướng đến trang hóa đơn sau khi thanh toán
            return RedirectToAction("Invoice", new { id = benhNhan.BenhNhanId });
        }



        public async Task<IActionResult> CreateQR(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var apiRequest = new ApiRequest();
            apiRequest.acqId = Convert.ToInt32("970423");
            //MessageBox.Show(apiRequest.acqId.ToString());
            apiRequest.accountNo = ("06095317801");
            apiRequest.accountName = "Dao Xuan Truong";
            var amount =  _context.ChiTietThuocs.FirstOrDefault(x => x.BenhNhanId == id)?.TienThuoc ?? 0;
            var tienPhong = _context.ChiTietPhongs.FirstOrDefault(x => x.BenhNhanId == id)?.TienPhong ?? 0;
            var tienThuoc = _context.ChiTietThuocs
                                     .Where(x => x.BenhNhanId == id)
                                     .Sum(x => x.TienThuoc);
            var tienDichvu = _context.ChiTietDichVus
                                     .Where(x => x.BenhNhanId == id)
                                     .Sum(x => x.GiaTien);  // Tính tổng tiền dịch vụ

            var miengiam = _context.Bhyts.FirstOrDefault(x => x.BenhNhanId == id)?.MienGiam ?? 0;


            apiRequest.amount = Convert.ToInt32((tienPhong + tienThuoc + tienDichvu) * (1 - miengiam / 100m));
            apiRequest.addInfo = "Chuyển khoản tiền viện phí";
            apiRequest.format = "text";
            apiRequest.template = "print";

            var img = CreateQRCode(apiRequest);
            var file = img;
            var fileName = _context.BenhNhans.FirstOrDefault(x => x.BenhNhanId == id).BenhNhanId.ToString() + "QRCode.jpg";
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\imgQR", fileName);
            img.Save(path, ImageFormat.Jpeg);

            ViewBag.img = "/images/imgQR/" + fileName;

            return View();
        }




        public void GetListBank()
        {
            listBankData = new Bank();
            using (WebClient client = new WebClient())
            {
                var htmlData = client.DownloadData(URLBank);
                var bankRawJson = Encoding.UTF8.GetString(htmlData);

                listBankData = JsonConvert.DeserializeObject<Bank>(bankRawJson);

            }
        }



        public Image CreateQRCode(ApiRequest apiRequest)
        {


            //var apiRequest = new ApiRequest();
            //apiRequest.acqId = Convert.ToInt32("Id Ngân hàng");
            ////MessageBox.Show(apiRequest.acqId.ToString());
            //apiRequest.accountNo = long.Parse("số tài khoản");
            //apiRequest.accountName = "tên tài khoản";
            //apiRequest.amount = Convert.ToInt32("số tiền");
            //apiRequest.addInfo = "Nội dung chuyển khoản";
            //apiRequest.format = "text";
            //apiRequest.template ="dạng QR";
            var jsonRequest = JsonConvert.SerializeObject(apiRequest);
            // use restsharp for request api.
            var clients = new RestClient(URLQRCode);
            var request = new RestRequest();

            request.Method = RestSharp.Method.Post;
            request.AddHeader("Accept", "application/json");

            request.AddParameter("application/json", jsonRequest, ParameterType.RequestBody);

            var response = clients.Execute(request);
            var content = response.Content;
            var dataResult = JsonConvert.DeserializeObject<ApiResponse>(content);


            var image = Base64ToImage(dataResult.data.qrDataURL.Replace("data:image/png;base64,", ""));
            return image;
        }

        public Image Base64ToImage(string base64String)
        {
            byte[] imageBytes = Convert.FromBase64String(base64String);
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = Image.FromStream(ms, true);
            return image;
        }


        [HttpGet]
        public JsonResult GetPhongByKhoa(int khoaId)
        {
            var danhSachPhong = _context.Phongs
                .Where(p => p.KhoaId == khoaId)
                .Select(p => new { p.PhongId, p.SoPhong })
                .ToList();
            return Json(danhSachPhong);
        }
        [HttpGet]
        public JsonResult GetBacSiByKhoa(int khoaId)
        {
            var danhSachBacSi = _context.BacSis
                .Where(b => b.KhoaId == khoaId)
                .Select(b => new { b.BacSiId, b.HoTen })
                .ToList();

            return Json(danhSachBacSi);
        }

    }
}
