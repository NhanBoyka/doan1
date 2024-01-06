using doan1.Data.Base;
using doan1.Data.ViewModels;
using doan1.Models;
using Microsoft.EntityFrameworkCore;

namespace doan1.Data.Service
{
    public class ProductsService : EntityBaseRepository<Product>, IProductsService
    {
        private readonly AppDbContext _context;
        public ProductsService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewProductAsync(NewProductVM data)
        {
            var newProduct = new Product()
            {
                ImageURL = data.ImageURL,
                Name = data.Name,
                Price = data.Price,
                Description = data.Description,
                ProductCategory = data.ProductCategory,
                BrandId = data.BrandId,
            };
            await _context.Products.AddAsync(newProduct);
            await _context.SaveChangesAsync();
        }

        public async Task<NewProductDropdownsVM> GetNewProductDropdownsValues()
        {
            var response = new NewProductDropdownsVM()
            {
                Brands = await _context.Brands.OrderBy(n => n.Name).ToListAsync()
            };

            return response;
        }

        public Task<Product> GetProductByIdAsync(int id)
        {
            var productDetails = _context.Products
                .Include(b => b.Brand)
                .FirstOrDefaultAsync(n => n.Id == id);
            return productDetails;
        }

        public async Task UpdateProductAsync(NewProductVM data)
        {
            var dbProduct =await _context.Products.FirstOrDefaultAsync(n => n.Id == data.Id);

            if (dbProduct != null)
            {
                dbProduct.ImageURL = data.ImageURL;
                dbProduct.Name = data.Name;
                dbProduct.Price = data.Price;
                dbProduct.Description = data.Description;
                dbProduct.ProductCategory = data.ProductCategory;
                dbProduct.BrandId = data.BrandId;
                await _context.SaveChangesAsync();
            }
        }
    }
}
