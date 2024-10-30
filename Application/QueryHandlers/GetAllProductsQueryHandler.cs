using Application.DTOs;
using Domain.Interfaces;

namespace Application;

public class GetAllProductsQueryHandler
{
    private readonly IProductRepository _repository;

    public GetAllProductsQueryHandler(IProductRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<List<ProductDto>> Handle(GetAllProductsQuery query)
    {
        var products = await _repository.GetAllProductsAsync();
        var productDtos = new List<ProductDto>();

        foreach (var product in products)
        {
            productDtos.Add(new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            });
        }

        return productDtos;
    }
    
}