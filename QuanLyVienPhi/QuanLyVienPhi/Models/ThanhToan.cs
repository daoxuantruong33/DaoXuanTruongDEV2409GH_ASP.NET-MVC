using System;
using System.Collections.Generic;

namespace QuanLyVienPhi.Models;

public partial class ThanhToan
{
    public int ThanhToanId { get; set; }

    public int HoaDonId { get; set; }

    public string HinhThuc { get; set; } = null!;

    public DateOnly NgayThanhToan { get; set; }

    public decimal SoTien { get; set; }

    public int ThuNganId { get; set; }

    public virtual HoaDon HoaDon { get; set; } = null!;

    public virtual ThuNgan ThuNgan { get; set; } = null!;
}
