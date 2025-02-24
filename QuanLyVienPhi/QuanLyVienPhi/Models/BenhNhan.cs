using System;
using System.Collections.Generic;

namespace QuanLyVienPhi.Models;

public partial class BenhNhan
{
    public int BenhNhanId { get; set; }

    public string HoTen { get; set; } = null!;

    public DateOnly? NgaySinh { get; set; }

    public string? GioiTinh { get; set; }

    public string? DiaChi { get; set; }

    public string? DienThoai { get; set; }

    public string? Cmnd { get; set; }

    public DateOnly NgayNhapVien { get; set; }

    public DateOnly? NgayRaVien { get; set; }

    public int? BacSiId { get; set; }

    public int? KhoaId { get; set; }

    public int? PhongId { get; set; }

    public decimal? TienThuoc { get; set; }

    public decimal? TienPhong { get; set; }

    public bool TrangThaiThanhToan { get; set; }

    public virtual BacSi? BacSi { get; set; }

    public virtual ICollection<ChiTietPhong> ChiTietPhongs { get; set; } = new List<ChiTietPhong>();

    public virtual ICollection<ChiTietThuoc> ChiTietThuocs { get; set; } = new List<ChiTietThuoc>();

    public virtual ICollection<HoaDon> HoaDons { get; set; } = new List<HoaDon>();

    public virtual Khoa? Khoa { get; set; }

    public virtual Phong? Phong { get; set; }
}
