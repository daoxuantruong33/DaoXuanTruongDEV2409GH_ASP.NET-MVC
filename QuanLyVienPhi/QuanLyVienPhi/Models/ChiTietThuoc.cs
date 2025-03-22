using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuanLyVienPhi.Models;

public partial class ChiTietThuoc
{
    public int ChiTietThuocId { get; set; }
    [Display(Name = "Bệnh Nhân")]

    public int BenhNhanId { get; set; }
    [Display(Name = "CCCD")]

    public string? Cccd { get; set; }
    [Display(Name = "Tên Thuốc")]

    public int ThuocId { get; set; }
    [Display(Name = "Số Lượng")]

    public int SoLuong { get; set; }
    [Display(Name = "Tiền Thuốc")]

    public decimal? TienThuoc { get; set; }
    [Display(Name = "Ngày tạo")]

    public DateTime? CreatedDate { get; set; }
    [Display(Name = "Cập Nhật Mới")]

    public DateTime? UpdatedDate { get; set; }
    [Display(Name = "Bệnh Nhân")]

    public virtual BenhNhan? BenhNhan { get; set; } = null!;
    [Display(Name = "Tên Thuốc")]

    public virtual Thuoc? Thuoc { get; set; } = null!;
}
