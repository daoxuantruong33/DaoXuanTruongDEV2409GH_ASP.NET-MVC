using System;
using System.Collections.Generic;

namespace QuanLyVienPhi.Models;

public partial class DichVu
{
    public int DichVuId { get; set; }

    public string TenDichVu { get; set; } = null!;

    public decimal GiaTien { get; set; }

    public virtual ICollection<ChiTietDichVu> ChiTietDichVus { get; set; } = new List<ChiTietDichVu>();
}
