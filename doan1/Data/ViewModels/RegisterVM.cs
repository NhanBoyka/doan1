using System.ComponentModel.DataAnnotations;

namespace doan1.Data.ViewModels
{
    public class RegisterVM
    {
        [Display(Name = "Tên người dùng")]
        [Required(ErrorMessage = "Tên người dùng không được để trống")]
        public string FullName { get; set; }
        [Display(Name = "Địa chỉ Email")]
        [Required(ErrorMessage = "Email không được để trống")]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Email phải từ 8 kí tự trở lên")]
        public string EmailAddress { get; set; }

        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Xác nhận mật khẩu")]
        [Required(ErrorMessage = "Xác nhận mật khẩu không được để trống")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Mật khẩu không trùng khớp")]
        public string? ConfirmPassword { get; set; }
    }
}
