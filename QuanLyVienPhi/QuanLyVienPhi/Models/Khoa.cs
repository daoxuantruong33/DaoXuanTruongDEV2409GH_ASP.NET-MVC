using System;
using System.Collections.Generic;

namespace QuanLyVienPhi.Models;

public partial class Khoa
{
    public int KhoaId { get; set; }

    public string TenKhoa { get; set; } = null!;

    public string? MoTa { get; set; }

    public virtual ICollection<BacSi> BacSis { get; set; } = new List<BacSi>();

    public virtual ICollection<BenhNhan> BenhNhans { get; set; } = new List<BenhNhan>();

    public virtual ICollection<Phong> Phongs { get; set; } = new List<Phong>();
}
