using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DevXuongMoc.Models;

public partial class Category
{
    [Display(Name = "Hirnh")]
    public int Id { get; set; }

    [Display(Name = "Tiêu đề")]
    public string? Title { get; set; }

    [Display(Name = "Biểu tượng")]
    public string? Icon { get; set; }

    [Display(Name = "Meta Tiêu đề")]
    public string? MateTitle { get; set; }

    [Display(Name = "Meta Từ khóa")]
    public string? MetaKeyword { get; set; }

    [Display(Name = "Meta Mô tả")]
    public string? MetaDescription { get; set; }

    [Display(Name = "Slug")]
    public string? Slug { get; set; }

    [Display(Name = "Thứ tự")]
    public int? Orders { get; set; }

    [Display(Name = "Mã cha")]
    public int? Parentid { get; set; }

    [Display(Name = "Ngày tạo")]
    public DateTime? CreatedDate { get; set; }

    [Display(Name = "Ngày cập nhật")]
    public DateTime? UpdatedDate { get; set; }

    [Display(Name = "Người tạo")]
    public string? AdminCreated { get; set; }

    [Display(Name = "Người cập nhật")]
    public string? AdminUpdated { get; set; }

    [Display(Name = "Ghi chú")]
    public string? Notes { get; set; }

    [Display(Name = "Trạng thái")]
    public byte? Status { get; set; }

    [Display(Name = "Đã xóa")]
    public bool? Isdelete { get; set; }
}
