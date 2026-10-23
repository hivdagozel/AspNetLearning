using AspNetLearning.Api.Models;
using AspNetLearning.Api.Repositories;

namespace AspNetLearning.Api.Services
{
    public class ProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public bool IsValid(Product? product)
        {
            if (product is null)
                return false;

            if (string.IsNullOrWhiteSpace(product.Name))
                return false;

            if (product.Price <= 0)
                return false;

            if (product.Stock < 0)
                return false;

            return true;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _productRepository.GetAllAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            if (id <= 0)
                return null;

            return await _productRepository.GetByIdAsync(id);
        }

        public async Task<Product?> AddAsync(Product? product)
        {
            if (!IsValid(product))
                return null;

            return await _productRepository.AddAsync(product!);
        }

        public async Task<bool> UpdateAsync(Product? product)
        {
            if (!IsValid(product))
                return false;

            return await _productRepository.UpdateAsync(product!);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            if (id <= 0)
                return false;

            return await _productRepository.DeleteAsync(id);
        }
    }
}