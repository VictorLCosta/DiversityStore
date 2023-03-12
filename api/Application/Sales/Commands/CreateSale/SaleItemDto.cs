using Api.Application.Common.Mappings;
using Api.Domain.Entities;

using AutoMapper;

namespace Api.Application.Sales.Commands.CreateSale;

public class SaleItemDto : IMapFrom<SaleItem>
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }

    public void Mapping(Profile profile)
    {
        profile
            .CreateMap<SaleItemDto, SaleItem>()
            .ReverseMap();
    }
}
