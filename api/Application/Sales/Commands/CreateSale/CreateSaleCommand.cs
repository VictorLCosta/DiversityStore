using Api.Application.Common.Interfaces;
using Api.Application.Common.Models;
using Api.Domain.Entities;

using AutoMapper;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace Api.Application.Sales.Commands.CreateSale;

public class CreateSaleCommand
{
    public class Command : IRequest<Result<Unit>>
    {
        public List<SaleItemDto> SaleItems { get; set; } = null!;
    }

    public class Handler : IRequestHandler<Command, Result<Unit>>
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Handler(ICurrentUserService currentUserService, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _currentUserService = currentUserService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
        {
            var saleItems = new List<SaleItem>();

            foreach(var item in request.SaleItems)
            {
                var totalItemPrice = await _unitOfWork
                    .ProductRepository
                    .AsQueryable(x => x.Id == item.ProductId)
                    .Select(x => x.Price * item.Quantity)
                    .FirstOrDefaultAsync();

                saleItems.Add(new SaleItem 
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    Price = totalItemPrice,
                });

                var stock = await _unitOfWork.StockRepository.GetByProductIdAsync(item.ProductId);

                stock.QuantityInStock -= item.Quantity;

                await _unitOfWork.StockRepository.UpdateAsync(stock);

                await _unitOfWork.Complete();
            }

            var saleTotalAmount = saleItems.Sum(x => x.Price);

            var customerId = await _unitOfWork
                .CustomerRepository
                .AsQueryable(x => x.AppUser.Id == _currentUserService.UserId)
                .Select(x => x.Id)
                .FirstOrDefaultAsync();

            var sale = new Sale
            {
                SaleItems = saleItems,
                TotalAmount = saleTotalAmount,
                CustomerId = customerId
            };

            await _unitOfWork.SaleRepository.AddAsync(sale);

            return Result<Unit>.Success(Unit.Value);
        }
    }
}
