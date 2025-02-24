using System;
using System.Collections.Generic;

namespace QuanLyVienPhi.Models;

public partial class Phong
{
    public int PhongId { get; set; }

    public string SoPhong { get; set; } = null!;

    public string? TienPhongNgay { get; set; }

    public int KhoaId { get; set; }

    public virtual ICollection<BenhNhan> BenhNhans { get; set; } = new List<BenhNhan>();

    public virtual ICollection<ChiTietPhong> ChiTietPhongs { get; set; } = new List<ChiTietPhong>();

    public virtual Khoa Khoa { get; set; } = null!;
}
