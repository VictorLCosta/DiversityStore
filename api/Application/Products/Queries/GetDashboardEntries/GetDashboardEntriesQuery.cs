namespace Api.Application.Products.Queries.GetDashboardEntries;

using Api.Application.Common.Interfaces;
using Api.Application.Common.Mappings;
using Api.Application.Common.Models;

using AutoMapper;
using AutoMapper.QueryableExtensions;

using MediatR;

using Microsoft.AspNetCore.Mvc;

public class GetDashboardEntriesQuery
{
    public class Query : IRequest<Result<PaginatedList<DashboardEntryDto>>>
    {
        [FromQuery(Name = "pageNumber")]
        public int PageNumber { get; init; } = 1;

        [FromQuery(Name = "pageSize")]
        public int PageSize { get; init; } = 10;
    }

    public class Handler : IRequestHandler<Query, Result<PaginatedList<DashboardEntryDto>>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public Handler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<Result<PaginatedList<DashboardEntryDto>>> Handle(Query request, CancellationToken cancellationToken)
        {
            var products = await _uow
                .ProductRepository
                .AsQueryable()
                .ProjectTo<DashboardEntryDto>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize);

            return Result<PaginatedList<DashboardEntryDto>>.Success(products);
        }
    }
}
