using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Api.Application.Common.Interfaces;
using Api.Application.Common.Models;
using Api.Domain.Entities;

using AutoMapper;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace Api.Application.Products.Commands.UpdateProduct;

public class UpdateProductCommand
{
    public class Command : IRequest<Result<UpdateProductResultDto>>
    {
        public UpdateProductDto UpdateProductDto { get; set; } = null!;
    }

    public class Handler : IRequestHandler<Command, Result<UpdateProductResultDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Handler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<UpdateProductResultDto>> Handle(Command request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request.UpdateProductDto);

            product.Stock = await _unitOfWork
                .StockRepository
                .GetByProductIdAsync(product.Id);

            product.Stock.QuantityInStock = request.UpdateProductDto.QuantityOnStock;

            var result = await _unitOfWork.ProductRepository.UpdateAsync(product);

            if (result == null) return Result<UpdateProductResultDto>.Failure("Error on update product.");

            return Result<UpdateProductResultDto>.Success(_mapper.Map<UpdateProductResultDto>(result));
        }
    }
}
