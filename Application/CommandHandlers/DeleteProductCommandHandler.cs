using Domain.Interfaces;

namespace Application;

public class DeleteProductCommandHandler
{
    private readonly IProductRepository _repository;

    public DeleteProductCommandHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(DeleteProductCommand command)
    {
        await _repository.DeleteProductAsync(command.Id);
    }
}