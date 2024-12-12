using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DevXuongMoc.Models;

public partial class AdminUser
{
    [Display(Name = "Hirnh")]
    public int Id { get; set; }

    [Display(Name = "Tài khoản")]
    public string? Account { get; set; }

    [Display(Name = "Mật khẩu")]
    public string? Password { get; set; }

    [Display(Name = "Mã nhân sự")]
    public int? MaNhanSu { get; set; }

    [Display(Name = "Tên")]
    public string? Name { get; set; }

    [Display(Name = "Số điện thoại")]
    public string? Phone { get; set; }

    [Display(Name = "Email")]
    public string? Email { get; set; }

    [Display(Name = "Avatar")]
    public string? Avatar { get; set; }

    [Display(Name = "ID phòng ban")]
    public int? IdPhongBan { get; set; }

    [Display(Name = "Ngày tạo")]
    public DateTime? NgayTao { get; set; }

    [Display(Name = "Người tạo")]
    public string? NguoiTao { get; set; }

    [Display(Name = "Ngày cập nhật")]
    public DateTime? NgayCapNhat { get; set; }

    [Display(Name = "Người cập nhật")]
    public string? NguoiCapNhat { get; set; }

    [Display(Name = "Session Token")]
    public string? SessionToken { get; set; }

    [Display(Name = "Salt")]
    public string? Salt { get; set; }

    [Display(Name = "Quyền Admin")]
    public bool? IsAdmin { get; set; }

    [Display(Name = "Trạng thái")]
    public int? TrangThai { get; set; }

    [Display(Name = "Xóa")]
    public bool? IsDelete { get; set; }
}
