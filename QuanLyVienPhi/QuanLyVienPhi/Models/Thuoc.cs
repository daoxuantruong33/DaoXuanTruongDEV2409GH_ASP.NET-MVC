using System;
using System.Collections.Generic;

namespace QuanLyVienPhi.Models;

public partial class Thuoc
{
    public int ThuocId { get; set; }

    public string TenThuoc { get; set; } = null!;

    public decimal GiaTien { get; set; }

    public virtual ICollection<ChiTietThuoc> ChiTietThuocs { get; set; } = new List<ChiTietThuoc>();
}
