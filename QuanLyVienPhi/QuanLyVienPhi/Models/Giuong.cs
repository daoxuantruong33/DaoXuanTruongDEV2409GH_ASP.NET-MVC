using System;
using System.Collections.Generic;

namespace QuanLyVienPhi.Models;

public partial class Giuong
{
    public int GiuongId { get; set; }

    public string SoGiuong { get; set; } = null!;

    public int PhongId { get; set; }

    public string TrangThai { get; set; } = null!;

    public virtual ICollection<ChiTietPhong> ChiTietPhongs { get; set; } = new List<ChiTietPhong>();

    public virtual Phong? Phong { get; set; } = null!;
}
