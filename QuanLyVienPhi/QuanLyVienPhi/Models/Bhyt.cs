using System;
using System.Collections.Generic;

namespace QuanLyVienPhi.Models;

public partial class Bhyt
{
    public int BhytId { get; set; }

    public int BenhNhanId { get; set; }

    public string? Cccd { get; set; }

    public int DoiTuongId { get; set; }

    public string SoTheBhyt { get; set; } = null!;

    public decimal? MienGiam { get; set; }

    public virtual BenhNhan BenhNhan { get; set; } = null!;

    public virtual DoiTuong DoiTuong { get; set; } = null!;
}
