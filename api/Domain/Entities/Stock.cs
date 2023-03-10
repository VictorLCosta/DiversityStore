namespace Api.Domain.Entities;

public class Stock : BaseEntity
{
    public int QuantityInStock { get; set; }

    public Guid ProductId { get; set; }
    public Product Product { get; set; } = null!;
}
