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

    public string? Cccd { get; set; }

    public DateOnly NgayNhapVien { get; set; }

    public DateOnly? NgayRaVien { get; set; }

    public int? BacSiId { get; set; }

    public int? KhoaId { get; set; }

    public int? PhongId { get; set; }

    public decimal? TienThuoc { get; set; }

    public decimal? TienPhong { get; set; }

    public decimal? TienDichVu { get; set; }

    public bool TrangThaiThanhToan { get; set; }

    public int? ThuNganId { get; set; }

    public decimal? MienGiam { get; set; }

    public virtual BacSi? BacSi { get; set; }

    public virtual ICollection<Bhyt> Bhyts { get; set; } = new List<Bhyt>();

    public virtual ICollection<ChiTietDichVu> ChiTietDichVus { get; set; } = new List<ChiTietDichVu>();

    public virtual ICollection<ChiTietPhong> ChiTietPhongs { get; set; } = new List<ChiTietPhong>();

    public virtual ICollection<ChiTietThuoc> ChiTietThuocs { get; set; } = new List<ChiTietThuoc>();

    public virtual Khoa? Khoa { get; set; }

    public virtual Phong? Phong { get; set; }

    public virtual ThuNgan? ThuNgan { get; set; }
}
