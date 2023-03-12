using Api.Application.Sales.Commands.CreateSale;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Web.Controllers;

[Authorize(Roles = "Administrator, Customer")]
public class SalesController : BaseApiController
{
    [HttpPost("create")]
    public async Task<IActionResult> CreateSale(List<SaleItemDto> items)
    {
        var result = await Mediator.Send(new CreateSaleCommand.Command { SaleItems = items});

        return HandleResult(result);
    }
}
