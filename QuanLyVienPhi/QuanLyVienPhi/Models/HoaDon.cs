using System;
using System.Collections.Generic;

namespace QuanLyVienPhi.Models;

public partial class HoaDon
{
    public int HoaDonId { get; set; }

    public int BenhNhanId { get; set; }

    public decimal TienPhong { get; set; }

    public decimal TienThuoc { get; set; }

    public decimal? TongTien { get; set; }

    public virtual BenhNhan BenhNhan { get; set; } = null!;

    public virtual ICollection<ThanhToan> ThanhToans { get; set; } = new List<ThanhToan>();
}
