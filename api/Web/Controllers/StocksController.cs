using Api.Application.Stocks.Queries.CheckProductQuantity;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Web.Controllers;

[Authorize(Roles = "Administrator, Customer")]
public class StocksController : BaseApiController
{
    [HttpGet("check-quantity")]
    public async Task<IActionResult> CheckAvailableStockQuantity(Guid productId, int quantity)
    {
        var result = await Mediator.Send(new CheckProductQuantityQuery.Query { ProductId = productId, Quantity = quantity });

        return HandleResult(result);
    }
}
