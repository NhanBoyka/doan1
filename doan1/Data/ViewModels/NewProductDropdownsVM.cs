using doan1.Models;

namespace doan1.Data.ViewModels
{
    public class NewProductDropdownsVM
    {
        public NewProductDropdownsVM()
        {
            Brands = new List<Brand>();
        }
        public List<Brand> Brands { get; set; }
    }
}
