using Api.Application.Products.Queries.GetProducts;

using Microsoft.AspNetCore.Mvc;

namespace Api.Web.Controllers;

public class ProductsController : BaseApiController
{
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GetProductsQuery.Query query)
    {
        var result = await Mediator.Send(query);

        return HandleResult(result);
    }
}
