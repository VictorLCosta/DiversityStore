using Api.Application.Common.Interfaces;
using Api.Application.Common.Models;

using AutoMapper;
using AutoMapper.QueryableExtensions;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace Api.Application.Products.Queries.GetProduct;

public class GetProductQuery
{
    public class Query : IRequest<Result<ProductDto>>
    {
        public string? Slug { get; set; }
    }

    public class Handler : IRequestHandler<Query, Result<ProductDto>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public Handler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<Result<ProductDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var product = await _uow
                .ProductRepository
                .AsQueryable(x => x.Slug == request.Slug && x.Status == 0)
                .Include(x => x.Stock)
                .ProjectTo<ProductDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

            return Result<ProductDto>.Success(product!);
        }
    }
}
