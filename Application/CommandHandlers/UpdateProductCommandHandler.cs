using Domain.Interfaces;

namespace Application;

public class UpdateProductCommandHandler
{
    private readonly IProductRepository _repository;

    public UpdateProductCommandHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateProductCommand command)
    {
        var product = await _repository.GetProductByIdAsync(command.Id);
        if (product == null)
        {
            throw new Exception("Product not found.");
        }

        product.Name = command.Name;
        product.Price = command.Price;

        await _repository.UpdateProductAsync(product);
    }
}