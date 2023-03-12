using Api.Application.Common.Interfaces;
using Api.Application.Common.Mappings;
using Api.Application.Common.Models;

using AutoMapper;
using AutoMapper.QueryableExtensions;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Products.Queries.GetProducts;

public class GetProductsQuery
{
    public class Query : IRequest<Result<PaginatedList<ProductBriefDto>>>
    {
        [FromQuery(Name = "pageNumber")]
        public int PageNumber { get; init; } = 1;

        [FromQuery(Name = "pageSize")]
        public int PageSize { get; init; } = 8;
    }

    public class Handler : IRequestHandler<Query, Result<PaginatedList<ProductBriefDto>>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public Handler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<Result<PaginatedList<ProductBriefDto>>> Handle(Query request, CancellationToken cancellationToken)
        {
            var products = await _uow
                .ProductRepository
                .AsQueryable(x => x.Status == 0)
                .ProjectTo<ProductBriefDto>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize);

            return Result<PaginatedList<ProductBriefDto>>.Success(products);
        }
    }
}
