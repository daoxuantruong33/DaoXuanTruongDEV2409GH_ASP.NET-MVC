using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuanLyVienPhi.Models;

public partial class ChiTietPhong
{
    public int ChiTietPhongId { get; set; }

    public int BenhNhanId { get; set; }

    public string? Cccd { get; set; }
    [Display(Name = "Giường")]

    public int? GiuongId { get; set; }
    [Display(Name = "Phòng")]

    public int PhongId { get; set; }
    [Display(Name = "Ngày Nằm Viện")]

    public DateOnly NgayBatDau { get; set; }
    [Display(Name = "Ngày Ra Viện")]

    public DateOnly? NgayKetThuc { get; set; }
    [Display(Name = "Tiền Phòng")]

    public decimal TienPhong { get; set; }
    [Display(Name = "Ngày Tạo")]

    public DateTime? CreatedDate { get; set; }
    [Display(Name = "Cập Nhật Mới")]

    public DateTime? UpdatedDate { get; set; }

    public virtual BenhNhan? BenhNhan { get; set; } = null!;
    [Display(Name = "Giường")]

    public virtual Giuong? Giuong { get; set; }
    [Display(Name = "Phòng")]

    public virtual Phong? Phong { get; set; } = null!;
}
