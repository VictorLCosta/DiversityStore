using Api.Application.Common.Mappings;
using Api.Domain.Entities;
using Api.Domain.Enum;

using AutoMapper;

namespace Api.Application.Products.Queries.GetDashboardEntries;

public class DashboardEntryDto : IMapFrom<Product>
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Slug { get; set; }
    public decimal Price { get; set; }
    public int QuantityInStock { get; set; }

    public ProductStatus Status { get; set; }

    public void Mapping(Profile profile)
    {
        profile
            .CreateMap<Product, DashboardEntryDto>()
            .ForMember(x => x.QuantityInStock, opt => opt.MapFrom(src => src.Stock.QuantityInStock))
            .ReverseMap();
    }
}
