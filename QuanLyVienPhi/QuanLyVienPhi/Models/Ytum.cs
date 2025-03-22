using System;
using System.Collections.Generic;

namespace QuanLyVienPhi.Models;

public partial class Ytum
{
    public int YtaId { get; set; }

    public string HoTen { get; set; } = null!;

    public DateOnly? NgaySinh { get; set; }

    public string? GioiTinh { get; set; }

    public string? DienThoai { get; set; }

    public string? Email { get; set; }
}
