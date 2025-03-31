using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuanLyVienPhi.Models;

public partial class Bhyt
{
    public int BhytId { get; set; }
    [Display(Name = "Bệnh Nhân")]

    public int BenhNhanId { get; set; }
    [Display(Name = "CCCD")]

    public string? Cccd { get; set; }
    [Display(Name = "Đối Tượng")]

    public int DoiTuongId { get; set; }
    [Display(Name = "Số Thẻ BHYT")]

    public string SoTheBhyt { get; set; } = null!;
    [Display(Name = "Miễn Giảm (%)")]

    public decimal? MienGiam { get; set; }
    [Display(Name = "Ngày Tạo")]

    public DateTime? CreatedDate { get; set; }
    [Display(Name = "Cập Nhật Mới")]

    public DateTime? UpdatedDate { get; set; }

    public virtual BenhNhan? BenhNhan { get; set; } = null!;

    public virtual DoiTuong? DoiTuong { get; set; } = null!;
}
