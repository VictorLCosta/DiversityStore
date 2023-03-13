using Api.Application.Common.Mappings;
using Api.Domain.Entities;

using AutoMapper;

namespace Api.Application.Products.Queries.GetProduct;

public class ProductDto : IMapFrom<Product>
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Slug { get; set; }
    public string? Description { get; set; }
    public string? PictureUrl { get; set; }
    public decimal Price { get; set; }

    public int QuantityInStock { get; set; }

    public void Mapping(Profile profile)
    {
        profile
            .CreateMap<Product, ProductDto>()
            .ForMember(x => x.QuantityInStock, opt => opt.MapFrom(src => src.Stock.QuantityInStock))
            .ReverseMap();
    }
}
