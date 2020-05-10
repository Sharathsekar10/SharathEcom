using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Interface;
using Core.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context)
        {
            _context = context;

        }
        public async Task<IReadOnlyList<Product>> GetAllProduct()
        {
           return await _context.Products
                                .Include(p=>p.ProductBrand)
                                .Include(p=>p.ProductType)
                                .ToListAsync();
        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrands()
        {
            return await _context.ProductBrands.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
           return await _context.Products
                                .Include(p=>p.ProductBrand)
                                .Include(p=>p.ProductType)
                                .FirstOrDefaultAsync(p=>p.Id == id);
        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypes()
        {
           return await _context.ProductTypes.ToListAsync();
        }
    }
}