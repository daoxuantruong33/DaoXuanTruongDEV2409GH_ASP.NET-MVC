using System;
using System.ComponentModel.DataAnnotations;

namespace DevXuongMoc.Models
{
    public partial class Partner
    {
        [Display(Name = "Mã đối tác")]
        public int Id { get; set; }

        [Display(Name = "Tên đối tác")]
        public string? Title { get; set; }

        [Display(Name = "Logo")]
        public string? Logo { get; set; }

        [Display(Name = "URL")]
        public string? Url { get; set; }

        [Display(Name = "Thứ tự")]
        public byte? Orders { get; set; }

        [Display(Name = "Ngày tạo")]
        public DateTime? CreatedDate { get; set; }

        [Display(Name = "Ngày cập nhật")]
        public DateTime? UpdatedDate { get; set; }

        [Display(Name = "Người tạo")]
        public string? AdminCreated { get; set; }

        [Display(Name = "Người cập nhật")]
        public string? AdminUpdated { get; set; }

        [Display(Name = "Nội dung")]
        public string? Content { get; set; }

        [Display(Name = "Trạng thái")]
        public byte? Status { get; set; }

        [Display(Name = "Đã xóa")]
        public bool? Isdelete { get; set; }
    }
}
