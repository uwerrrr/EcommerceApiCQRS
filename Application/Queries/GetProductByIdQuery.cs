namespace Application;

public class GetProductByIdQuery
{
    public Guid ProductId { get; }

    public GetProductByIdQuery(Guid productId)
    {
        ProductId = productId;
    }
}