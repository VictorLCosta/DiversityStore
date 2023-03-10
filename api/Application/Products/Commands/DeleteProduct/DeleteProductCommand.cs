using Api.Application.Common.Interfaces;
using Api.Application.Common.Models;

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
            var result = await _unitOfWork
                .ProductRepository
                .DeleteAsync(request.ProductId);

            if (result) return Result<Unit>.Success(Unit.Value);

            return Result<Unit>.Failure("Error on delete product.");
        }
    }
}
