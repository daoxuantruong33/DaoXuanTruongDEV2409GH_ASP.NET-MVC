using System;
using System.Collections.Generic;

namespace QuanLyVienPhi.Models;

public partial class ChiTietThuoc
{
    public int ChiTietThuocId { get; set; }

    public int BenhNhanId { get; set; }

    public int ThuocId { get; set; }

    public int SoLuong { get; set; }

    public decimal? TienThuoc { get; set; }

    public virtual BenhNhan? BenhNhan { get; set; } = null!;

    public virtual Thuoc? Thuoc { get; set; } = null!;
}
