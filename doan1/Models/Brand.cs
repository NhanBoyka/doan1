using doan1.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace doan1.Models
{
    public class Brand : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Logo")]
        [Required(ErrorMessage = "Logo không được bỏ trống")]
        public string Logo { get; set; }
        [Display(Name ="Tên thương hiệu")]
        [Required(ErrorMessage = "Tên thương hiệu không được bỏ trống")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Tên thương hiệu cần 3 đến 50 kí tự")]
        public string Name { get; set; }
        [Display(Name = "Địa chỉ")]
        [Required(ErrorMessage = "Địa chỉ không được bỏ trống")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Địa chỉ cần 3 đến 50 kí tự")]
        public string Address { get; set; }
        [Display(Name = "Số điện thoại")]
        [Required(ErrorMessage = "Số điện thoại không được bỏ trống")]
        public int PhoneNumber {  get; set; }
        [Display(Name = "Email ")]
        [Required(ErrorMessage = "Email không được bỏ trống")]
        public string Email { get; set; }
        [Display(Name = "Miêu tả")]
        [Required(ErrorMessage = "Miêu tả không được bỏ trống")]
        public string Description { get; set; }

        //Relationship
        public List<Product>? Products { get; set; }
    }
}
