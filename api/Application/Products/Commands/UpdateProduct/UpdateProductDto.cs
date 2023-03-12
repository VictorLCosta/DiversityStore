using Api.Application.Common.Extensions;
using Api.Application.Common.Mappings;
using Api.Domain.Entities;

using AutoMapper;

namespace Api.Application.Products.Commands.UpdateProduct;

public class UpdateProductDto : IMapFrom<Product>
{
    public Guid Id { get; set; }
    public string? Name { get; init; }
    public string? Description { get; init; }
    public string? PictureUrl { get; set; }
    public decimal Price { get; init; }

    public int QuantityOnStock { get; set; }

    public void Mapping(Profile profile)
    {
        profile
            .CreateMap<UpdateProductDto, Product>()
            .ForMember(x => x.Slug, opt => opt.MapFrom(src => src.Name!.GenerateSlug()))
            .ReverseMap();
    }
}
