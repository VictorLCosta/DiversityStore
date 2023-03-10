using Api.Application.Common.Mappings;
using Api.Domain.Entities;

namespace Api.Application.Products.Queries.GetProducts;

public class ProductBriefDto : IMapFrom<Product>
{
    public string? Name { get; set; }
    public string? Slug { get; set; }
    public string? Description { get; set; }
    public string? PictureUrl { get; set; }
    public decimal Price { get; set; }
}
