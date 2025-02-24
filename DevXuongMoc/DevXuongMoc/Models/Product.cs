using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DevXuongMoc.Models
{
    public partial class Product
    {
        [Display(Name = "Mã sản phẩm")]
        public int Id { get; set; }

        [Display(Name = "Danh mục")]
        public int? Cid { get; set; }

        [Display(Name = "Mã")]
        public string? Code { get; set; }

        [Display(Name = "Tiêu đề")]
        public string? Title { get; set; }

        [Display(Name = "Mô tả")]
        public string? Description { get; set; }

        [Display(Name = "Nội dung")]
        public string? Content { get; set; }

        [Display(Name = "Hình ảnh")]
        public string? Image { get; set; }

        [Display(Name = "Tiêu đề Meta")]
        public string? MetaTitle { get; set; }

        [Display(Name = "Từ khóa Meta")]
        public string? MetaKeyword { get; set; }

        [Display(Name = "Mô tả Meta")]
        public string? MetaDescription { get; set; }

        [Display(Name = "Slug")]
        public string? Slug { get; set; }

        [Display(Name = "Giá cũ")]
        public decimal? PriceOld { get; set; }

        [Display(Name = "Giá mới")]
        public decimal? PriceNew { get; set; }

        [Display(Name = "Kích thước")]
        public string? Size { get; set; }

        [Display(Name = "Lượt xem")]
        public int? Views { get; set; }

        [Display(Name = "Lượt thích")]
        public int? Likes { get; set; }

        [Display(Name = "Sao đánh giá")]
        public double? Star { get; set; }

        [Display(Name = "Trang chủ")]
        public byte? Home { get; set; }

        [Display(Name = "Nổi bật")]
        public byte? Hot { get; set; }

        [Display(Name = "Ngày tạo")]
        public DateTime? CreatedDate { get; set; }

        [Display(Name = "Ngày cập nhật")]
        public DateTime? UpdatedDate { get; set; }

        [Display(Name = "Admin tạo")]
        public string? AdminCreated { get; set; }

        [Display(Name = "Admin cập nhật")]
        public string? AdminUpdated { get; set; }

        [Display(Name = "Trạng thái")]
        public byte? Status { get; set; }

        [Display(Name = "Đã xóa")]
        public bool? Isdelete { get; set; }
    }
}
