using Application.DTOs;
using Domain.Interfaces;

namespace Application;

public class GetProductByIdQueryHandler
{
    private readonly IProductRepository _repository;

    public GetProductByIdQueryHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<ProductDto> Handle(GetProductByIdQuery query)
    {
        var product = await _repository.GetProductByIdAsync(query.ProductId);
        return new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price
        };
    }
}