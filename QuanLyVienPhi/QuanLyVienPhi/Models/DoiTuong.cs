using System;
using System.Collections.Generic;

namespace QuanLyVienPhi.Models;

public partial class DoiTuong
{
    public int DoiTuongId { get; set; }

    public string? SoThe { get; set; }

    public decimal? MienGiam { get; set; }

    public virtual ICollection<Bhyt> Bhyts { get; set; } = new List<Bhyt>();
}
