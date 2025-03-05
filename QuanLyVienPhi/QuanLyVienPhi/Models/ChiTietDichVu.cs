using System;
using System.Collections.Generic;

namespace QuanLyVienPhi.Models;

public partial class ChiTietDichVu
{
    public int ChiTietDichVuId { get; set; }

    public int BenhNhanId { get; set; }

    public string Cccd { get; set; } = null!;

    public int DichVuId { get; set; }

    public string? TenDichVu { get; set; }

    public decimal GiaTien { get; set; }

    public virtual BenhNhan? BenhNhan { get; set; } = null!;

    public virtual DichVu? DichVu { get; set; } = null!;
}
