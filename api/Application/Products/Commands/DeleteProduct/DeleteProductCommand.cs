using Api.Application.Common.Interfaces;
using Api.Application.Common.Models;
using Api.Domain.Enum;

using MediatR;

namespace Api.Application.Products.Commands.DeleteProduct;

public class DeleteProductCommand
{
    public class Command : IRequest<Result<Unit>>
    {
        public Guid ProductId { get; set; }
    }

    public class Handler : IRequestHandler<Command, Result<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public Handler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork
                .ProductRepository
                .Get(request.ProductId);

            product!.Status = ProductStatus.Unavailable;

            var result = await _unitOfWork
                .ProductRepository
                .UpdateAsync(product);

            if (result == null) return Result<Unit>.Failure("Error on delete product.");

            return Result<Unit>.Success(Unit.Value);
        }
    }
}
