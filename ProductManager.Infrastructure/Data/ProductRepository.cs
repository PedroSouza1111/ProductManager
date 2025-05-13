
using Microsoft.EntityFrameworkCore;
using ProductManager.Domain.Entities;
using ProductManager.Domain.Interfaces;

namespace ProductManager.Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _context;

        public ProductRepository(ProductDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllAsync() => await _context.Products.ToListAsync();

        public async Task<Product?> GetByIdAsync(int id) => await _context.Products.FindAsync(id);

        public async Task<int> AddAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product.Id;
        }

        public async Task<bool> UpdateAsync(Product product)
        {
            _context.Products.Update(product);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return false;
            _context.Products.Remove(product);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
