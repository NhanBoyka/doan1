using doan1.Data.Base;
using doan1.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace doan1.Models
{
    public class Product : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Ảnh sản phẩm")]
        [Required(ErrorMessage = "Ảnh sản phẩm không được bỏ trống")]
        public string ImageURL { get; set; }
        [Display(Name = "Tên sản phẩm")]
        [Required(ErrorMessage = "Tên sản phẩm không được bỏ trống")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Tên sản phẩm cần 3 đến 50 kí tự")]
        public string Name { get; set; }
        [Display(Name = "Giá sản phẩm")]
        [Required(ErrorMessage = "Giá sản phẩm không được bỏ trống")]
        public int Price { get; set; }
        [Display(Name = "Miêu tả sản phẩm")]
        [Required(ErrorMessage = "Miêu tả sản phẩm không được bỏ trống")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Tên sản phẩm cần 3 đến 50 kí tự")]
        public string Description { get; set; }
        [Display(Name = "Loại danh mục sản phẩm")]
        [Required(ErrorMessage = "Danh mục sản phẩm không được bỏ trống")]
        public ProductCategory ProductCategory { get; set; }

        //relationship
        //public List<Cart> Carts { get; set; }
        //public List<Order_Detail> Order_Details { get; set; }

        //Brand
        public int BrandId { get; set; }
        [ForeignKey("BrandId")]

        public Brand Brand { get; set; }
    }
}
