using System;
using System.Collections.Generic;

namespace QuanLyVienPhi.Models;

public partial class ChiTietPhong
{
    public int ChiTietPhongId { get; set; }

    public int BenhNhanId { get; set; }

    public string? Cccd { get; set; }

    public int PhongId { get; set; }

    public DateOnly NgayBatDau { get; set; }

    public DateOnly? NgayKetThuc { get; set; }

    public decimal TienPhong { get; set; }

    public virtual BenhNhan BenhNhan { get; set; } = null!;

    public virtual Phong Phong { get; set; } = null!;
}
