using System.ComponentModel.DataAnnotations;

using Api.Application.Common.Extensions;
using Api.Application.Common.Mappings;
using Api.Domain.Entities;

using AutoMapper;

namespace Api.Application.Products.Commands.CreateProduct;

public class CreateProductDto : IMapFrom<Product>
{
    [Required]
    [MaxLength(250)]
    public string? Name { get; init; }

    [Required]
    public string? Description { get; init; }

    public string? PictureUrl { get; set; }

    [Range(1.0, double.MaxValue)]
    public decimal Price { get; init; }

    [Range(1.0, double.MaxValue)]
    public int InitialQuantityOnStock { get; set; }

    public void Mapping(Profile profile)
    {
        profile
            .CreateMap<CreateProductDto, Product>()
            .ForMember(x => x.Stock, opt => opt.MapFrom(src => new Stock { QuantityInStock = src.InitialQuantityOnStock }))
            .ForMember(x => x.Slug, opt => opt.MapFrom(src => src.Name!.GenerateSlug()))
            .ReverseMap();
    }
}
