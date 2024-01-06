using doan1.Data.Base;
using doan1.Models;
using Microsoft.EntityFrameworkCore;

namespace doan1.Data.Service
{
    public class BrandsService : EntityBaseRepository<Brand>, IBrandsService
    {
        public BrandsService(AppDbContext context) : base(context) { }
    }
}
