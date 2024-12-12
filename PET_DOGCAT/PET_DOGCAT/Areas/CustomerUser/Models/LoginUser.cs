using System.ComponentModel.DataAnnotations;

namespace PET_DOGCAT.Areas.CustomerUser.Models
{
    public class LoginUser
    {
        [Required(ErrorMessage = "Mã sinh viên không để trống")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Mật khẩu không để trống")]
        public string Password { get; set; }
        public bool Remember { get; set; }
        public int UserId { get; internal set; }
    }
}
