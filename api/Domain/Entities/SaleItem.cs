namespace Api.Domain.Entities;

public class SaleItem : BaseEntity
{
    public Guid ProductId { get; set; }
    public Product Product { get; set; } = null!;

    public Guid SaleId { get; set; }
    public Sale SalesOrder { get; set; } = null!;

    public decimal Price { get; set; }
    public int Quantity { get; set; }
}
