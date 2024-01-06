using System.ComponentModel.DataAnnotations;

namespace doan1.Data.ViewModels
{
    public class LoginVM
    {
        [Display(Name = "Địa chỉ Email")]
        [Required(ErrorMessage = "Email không được để trống")]
        public string EmailAddress { get; set; }

        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
