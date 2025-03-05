using System;
using System.Collections.Generic;

namespace QuanLyVienPhi.Models;

public partial class Role
{
    public int RoleId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Admin> Admins { get; set; } = new List<Admin>();

    public virtual ICollection<BacSi> BacSis { get; set; } = new List<BacSi>();

    public virtual ICollection<ThuNgan> ThuNgans { get; set; } = new List<ThuNgan>();
}
