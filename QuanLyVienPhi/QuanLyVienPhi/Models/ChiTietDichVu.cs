using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuanLyVienPhi.Models;

public partial class ChiTietDichVu
{
    public int ChiTietDichVuId { get; set; }
    [Display(Name = "Bệnh Nhân")]

    public int BenhNhanId { get; set; }
    [Display(Name = "CCCD")]

    public string Cccd { get; set; } = null!;
    [Display(Name = "Dịch Vụ")]

    public int DichVuId { get; set; }
    [Display(Name = "Tên Dịch Vụ")]

    public string? TenDichVu { get; set; }
    [Display(Name = "Giá Tiền")]

    public decimal GiaTien { get; set; }
    [Display(Name = "Ngày Tạo")]

    public DateTime? CreatedDate { get; set; }
    [Display(Name = "Cập Nhật Mới")]

    public DateTime? UpdatedDate { get; set; }
    [Display(Name = "Bệnh Nhân")]

    public virtual BenhNhan? BenhNhan { get; set; } = null!;
    [Display(Name = "Dịch Vụ")]

    public virtual DichVu? DichVu { get; set; } = null!;
}
