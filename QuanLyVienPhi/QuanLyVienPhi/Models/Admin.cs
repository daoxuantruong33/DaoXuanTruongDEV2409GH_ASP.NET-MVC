using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuanLyVienPhi.Models;

public partial class Admin
{    
    [Display(Name = "ID Admin")]

    public int AdminId { get; set; }
    [Display(Name = "Tên Admin")]

    public string Username { get; set; } = null!;
    [Display(Name = "Mật Khẩu")]

    public string Password { get; set; } = null!;
    [Display(Name = "Họ và tên")]

    public string? FullName { get; set; }
    [Display(Name = "SĐT")]

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public int? RoleId { get; set; }

    public virtual Role? Role { get; set; }
}
