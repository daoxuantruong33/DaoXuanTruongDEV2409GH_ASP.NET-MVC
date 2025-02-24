using System;
using System.ComponentModel.DataAnnotations;

namespace DevXuongMoc.Models
{
    public partial class Customer
    {
        [Display(Name = "Mã khách hàng")]
        public long Id { get; set; }

        [Display(Name = "Tên khách hàng")]
        public string? Name { get; set; }

        [Display(Name = "Tên đăng nhập")]
        public string? Username { get; set; }

        [Display(Name = "Mật khẩu")]
        public string? Password { get; set; }

        [Display(Name = "Địa chỉ")]
        public string? Address { get; set; }

        [Display(Name = "Email")]
        public string? Email { get; set; }

        [Display(Name = "Số điện thoại")]
        public string? Phone { get; set; }

        [Display(Name = "Ảnh đại diện")]
        public string? Avatar { get; set; }

        [Display(Name = "Ngày tạo")]
        public DateTime? CreatedDate { get; set; }

        [Display(Name = "Ngày cập nhật")]
        public DateTime? UpdatedDate { get; set; }

        [Display(Name = "Người tạo")]
        public long? CreatedBy { get; set; }

        [Display(Name = "Người cập nhật")]
        public long? UpdatedBy { get; set; }

        [Display(Name = "Đã xóa")]
        public byte? Isdelete { get; set; }

        [Display(Name = "Hoạt động")]
        public byte? Isactive { get; set; }
    }
}
