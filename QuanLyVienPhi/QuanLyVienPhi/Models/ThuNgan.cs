using System;
using System.Collections.Generic;

namespace QuanLyVienPhi.Models;

public partial class ThuNgan
{
    public int ThuNganId { get; set; }

    public string HoTen { get; set; } = null!;

    public string? DienThoai { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<BenhNhan> BenhNhans { get; set; } = new List<BenhNhan>();

    public virtual ICollection<ThanhToan> ThanhToans { get; set; } = new List<ThanhToan>();
}
