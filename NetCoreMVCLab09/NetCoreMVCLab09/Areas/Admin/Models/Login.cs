using System.ComponentModel.DataAnnotations;

namespace NetCoreMVCLab09.Areas.Admin.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Địa chỉ email không để trống")] public string Email { get; set; }
        [Required(ErrorMessage = "Mậ khẩu không để trống")] public string Password { get; set; }
        public bool Remember { get; set; }
    }
}
