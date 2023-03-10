namespace Api.Domain.Entities;

public class Product : BaseEntity
{
    private Product() {}

    public Product(string name, string description, decimal price, int initialQuantity = 0)
    {
        Name = name;
        Description = description;
        Price = price;
        Slug = name.ToLower().Replace(' ', '-');
        Stock = new Stock(initialQuantity);
    }

    public string? Name { get; set; }
    public string? Slug { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }

    public Stock Stock { get; set; } = null!;

    public ICollection<SaleItem> SaleItems { get; set; } = new List<SaleItem>();
}
