using Api.Application.Common.Interfaces;
using Api.Application.Common.Models;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace Api.Application.Stocks.Queries.CheckProductQuantity;

public class CheckProductQuantityQuery
{
    public class Query : IRequest<Result<bool>> 
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }

    public class Handler : IRequestHandler<Query, Result<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public Handler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<bool>> Handle(Query request, CancellationToken cancellationToken)
        {
            var stockQuantity = await _unitOfWork
                .StockRepository
                .AsQueryable(x => x.ProductId == request.ProductId)
                .Select(x => x.QuantityInStock)
                .FirstOrDefaultAsync();

            var result = stockQuantity >= request.Quantity;

            return Result<bool>.Success(result);
        }
    }
}
