using System.ComponentModel.DataAnnotations;

namespace DevXuongMoc.Models
{
    public class LoginUser
    {
        [Required(ErrorMessage = "Email không được để trống")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        public string Password { get; set; }
        public string UserOrEmail { get; set; }
    }
}
