using Api.Application.Common.Mappings;
using Api.Domain.Entities;

using AutoMapper;

namespace Api.Application.Products.Commands.CreateProduct;

public class CreateProductResultDto : IMapFrom<Product>
{
    public Guid Id { get; set; }
    public string? Name { get; init; }
    public string? Description { get; init; }
    public decimal Price { get; init; }

    public int QuantityOnStock { get; set; }

    public void Mapping(Profile profile)
    {
        profile
            .CreateMap<Product, CreateProductResultDto>()
            .ForMember(x => x.QuantityOnStock, opt => opt.MapFrom(src => src.Stock.QuantityInStock))
            .ReverseMap();
    }
}
