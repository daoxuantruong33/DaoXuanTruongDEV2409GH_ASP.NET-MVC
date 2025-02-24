using System;
using System.Collections.Generic;

namespace QuanLyVienPhi.Models;

public partial class BacSi
{
    public int BacSiId { get; set; }

    public string HoTen { get; set; } = null!;

    public string? ChuyenKhoa { get; set; }

    public string? DienThoai { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<BenhNhan> BenhNhans { get; set; } = new List<BenhNhan>();
}
