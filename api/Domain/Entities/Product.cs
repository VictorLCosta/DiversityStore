namespace Api.Domain.Entities;

public class Product : BaseEntity
{
    public string? Name { get; set; }
    public string? Slug { get; set; }
    public string? Description { get; set; }
    public string? PictureUrl { get; set; }
    public decimal Price { get; set; }

    public ProductStatus Status { get; set; }

    public Stock Stock { get; set; } = null!;

    public ICollection<SaleItem> SaleItems { get; set; } = new List<SaleItem>();
}
