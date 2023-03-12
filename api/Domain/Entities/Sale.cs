namespace Api.Domain.Entities;

public class Sale : BaseEntity
{
    public DateTimeOffset SaleDate { get; set; } = DateTimeOffset.Now;
    public decimal TotalAmount { get; set; }

    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;

    public ICollection<SaleItem> SaleItems { get; set; } = new List<SaleItem>();
}
