using Api.Application.Products.Commands.CreateProduct;
using Api.Application.Products.Commands.DeleteProduct;
using Api.Application.Products.Queries.GetProducts;

using Microsoft.AspNetCore.Authorization;
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

    [HttpPost]
    public async Task<IActionResult> Create(CreateProductDto createProductDto)
    {
        var result = await Mediator.Send(new CreateProductCommand.Command { CreateProductDto = createProductDto });

        return HandleResult(result);
    }

    [HttpDelete("{productId}")]
    public async Task<IActionResult> Delete(Guid productId)
    {
        var result = await Mediator.Send(new DeleteProductCommand.Command { ProductId = productId });

        return HandleResult(result);
    }
}
