using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    public async Task AddProductAsync(Product product)
    {
        // Implement database insert logic
    }

    public async Task<Product> GetProductByIdAsync(Guid id)
    {
        // Implement database get logic
        return new Product(); 
    }
    
    public async Task<List<Product>> GetAllProductsAsync()
    {
        // Implement database retrieval logic for all products
        return new List<Product>();
    }
    
    public async Task UpdateProductAsync(Product product)
    {
        // Implement database update logic
    }

    public async Task DeleteProductAsync(Guid id)
    {
        // Implement database delete logic
    }
    
}