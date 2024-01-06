using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace doan1.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "Tên người dùng")]
        public string FullName { get; set; }

    }
}
