
using ProductManager.Domain.Entities;
using ProductManager.Domain.Interfaces;

namespace ProductManager.Application.Services
{
    public class ProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public Task<List<Product>> GetAllAsync() => _repository.GetAllAsync();

        public Task<Product?> GetByIdAsync(int id) => _repository.GetByIdAsync(id);

        public async Task<int> CreateAsync(Product product) => await _repository.AddAsync(product);

        public async Task<bool> UpdateAsync(int id, Product updated)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return false;

            existing.Name = updated.Name;
            existing.Price = updated.Price;
            existing.Quantity = updated.Quantity;

            return await _repository.UpdateAsync(existing);
        }

        public Task<bool> DeleteAsync(int id) => _repository.DeleteAsync(id);
    }
}
