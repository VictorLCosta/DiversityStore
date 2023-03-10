using Api.Application.Common.Interfaces;
using Api.Application.Common.Models;
using Api.Domain.Entities;

using AutoMapper;

using MediatR;

namespace Api.Application.Products.Commands.CreateProduct;

public class CreateProductCommand
{
    public class Command : IRequest<Result<CreateProductResultDto>>
    {
        public CreateProductDto CreateProductDto { get; set; } = null!;
    }

    public class Handler : IRequestHandler<Command, Result<CreateProductResultDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Handler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<CreateProductResultDto>> Handle(Command request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request.CreateProductDto);

            var result = await _unitOfWork.ProductRepository.AddAsync(product);

            if (result == null) return Result<CreateProductResultDto>.Failure("Error on adding a new product.");

            return Result<CreateProductResultDto>.Success(_mapper.Map<CreateProductResultDto>(result));
        }
    }
}
