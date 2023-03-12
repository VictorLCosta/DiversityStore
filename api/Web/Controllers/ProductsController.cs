using Api.Application.Products.Commands.CreateProduct;
using Api.Application.Products.Commands.DeleteProduct;
using Api.Application.Products.Commands.UpdateProduct;
using Api.Application.Products.Queries.GetProduct;
using Api.Application.Products.Queries.GetProducts;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Web.Controllers;

[Authorize(Roles = "Administrator, Customer")]
public class ProductsController : BaseApiController
{
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GetProductsQuery.Query query)
    {
        var result = await Mediator.Send(query);

        return HandleResult(result);
    }

    [HttpGet("{slug}")]
    public async Task<IActionResult> Get(string slug)
    {
        var result = await Mediator.Send(new GetProductQuery.Query { Slug = slug });

        return HandleResult(result);
    }

    [HttpPost]
    [Authorize(Roles = "Administrator")]
    public async Task<IActionResult> Create(CreateProductDto createProductDto)
    {
        var result = await Mediator.Send(new CreateProductCommand.Command { CreateProductDto = createProductDto });

        return HandleResult(result);
    }

    [HttpPut]
    [Authorize(Roles = "Administrator")]
    public async Task<IActionResult> Update(UpdateProductDto updateProductDto)
    {
        var result = await Mediator.Send(new UpdateProductCommand.Command { UpdateProductDto = updateProductDto });

        return HandleResult(result);
    }

    [HttpDelete("{productId}")]
    [Authorize(Roles = "Administrator")]
    public async Task<IActionResult> Delete(Guid productId)
    {
        var result = await Mediator.Send(new DeleteProductCommand.Command { ProductId = productId });

        return HandleResult(result);
    }
}
