namespace Api.Domain.Entities;

public class Stock : BaseEntity
{
    private Stock() {}

    public Stock(int quantityInStock)
    {
        QuantityInStock = quantityInStock;
    }

    public int QuantityInStock { get; set; }

    public Guid ProductId { get; set; }
    public Product Product { get; set; } = null!;
}
