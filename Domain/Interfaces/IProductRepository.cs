using Domain.Entities;

namespace Domain.Interfaces;

public interface IProductRepository
{
    Task AddProductAsync(Product product);
    Task<Product> GetProductByIdAsync(Guid id);
    Task<List<Product>> GetAllProductsAsync();
    Task UpdateProductAsync(Product product); 
    Task DeleteProductAsync(Guid id);
}