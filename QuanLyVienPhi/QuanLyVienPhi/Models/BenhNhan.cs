using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuanLyVienPhi.Models;

public partial class BenhNhan
{
    public int BenhNhanId { get; set; }
    [Display(Name ="Bệnh Nhân")]
    public string HoTen { get; set; } = null!;
    [Display(Name = "Ngày Sinh")]
    public DateOnly? NgaySinh { get; set; }
    [Display(Name = "Giới Tính")]
    public string? GioiTinh { get; set; }
    [Display(Name = "Địa Chỉ")]
    public string? DiaChi { get; set; }
    [Display(Name = "SĐT")]
    public string? DienThoai { get; set; }
    [Display(Name = "CCCD")]
    public string? Cccd { get; set; }
    [Display(Name = "Ngày Nhập Viện")]

    public DateOnly NgayNhapVien { get; set; }
    [Display(Name = "Ngày Ra Viện")]

    public DateOnly? NgayRaVien { get; set; }
    [Display(Name = "Bác Sĩ")]

    public int? BacSiId { get; set; }
    [Display(Name = "Khoa")]

    public int? KhoaId { get; set; }
    [Display(Name = "Phòng")]

    public int? PhongId { get; set; }
    [Display(Name = "Tiền Thuốc")]

    public decimal? TienThuoc { get; set; }
    [Display(Name = "Tiền Phòng")]

    public decimal? TienPhong { get; set; }
    [Display(Name = "Tiền Dịch Vụ")]

    public decimal? TienDichVu { get; set; }
    [Display(Name = "Trạng Thái")]

    public bool TrangThaiThanhToan { get; set; }
    [Display(Name = "Thu Ngân")]

    public int? ThuNganId { get; set; }
    [Display(Name = "Miễn Giảm")]

    public decimal? MienGiam { get; set; }
    [Display(Name = "Ngày Tạo")]

    public DateTime? CreatedDate { get; set; }
    [Display(Name = "Cập Nhật Gần Đây")]

    public DateTime? UpdatedDate { get; set; }

    public virtual BacSi? BacSi { get; set; }

    public virtual ICollection<Bhyt> Bhyts { get; set; } = new List<Bhyt>();

    public virtual ICollection<ChiTietDichVu> ChiTietDichVus { get; set; } = new List<ChiTietDichVu>();

    public virtual ICollection<ChiTietPhong> ChiTietPhongs { get; set; } = new List<ChiTietPhong>();

    public virtual ICollection<ChiTietThuoc> ChiTietThuocs { get; set; } = new List<ChiTietThuoc>();

    public virtual Khoa? Khoa { get; set; }

    public virtual Phong? Phong { get; set; }

    public virtual ThuNgan? ThuNgan { get; set; }
}
