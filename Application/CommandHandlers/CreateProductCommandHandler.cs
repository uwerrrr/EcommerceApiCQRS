using Domain.Entities;
using Domain.Interfaces;

namespace Application;

public class CreateProductCommandHandler
{
    private readonly IProductRepository _repository;

    public CreateProductCommandHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(CreateProductCommand command)
    {
        var product = new Product
        {
            Id = Guid.NewGuid(),
            Name = command.Name,
            Price = command.Price
        };

        await _repository.AddProductAsync(product);
    }
}