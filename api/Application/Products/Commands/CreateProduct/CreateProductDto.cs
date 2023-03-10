using Api.Application.Common.Mappings;
using Api.Domain.Entities;

using AutoMapper;

namespace Api.Application.Products.Commands.CreateProduct;

public class CreateProductDto : IMapFrom<Product>
{
    public string? Name { get; init; }
    public string? Description { get; init; }
    public string? PictureUrl { get; set; }
    public decimal Price { get; init; }

    public int InitialQuantityOnStock { get; set; }

    public void Mapping(Profile profile)
    {
        profile
            .CreateMap<CreateProductDto, Product>()
            .ForMember(x => x.Stock, opt => opt.MapFrom(src => new Stock { QuantityInStock = src.InitialQuantityOnStock }))
            .ReverseMap();
    }
}
