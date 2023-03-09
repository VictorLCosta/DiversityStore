namespace Api.Domain.Entities;

public class Sale : BaseEntity
{
    public DateTimeOffset SaleDate { get; set; } = DateTimeOffset.Now;
    public decimal TotalAmount { get; set; }

    public ICollection<SaleItem> SaleItems { get; set; } = new List<SaleItem>();
}
