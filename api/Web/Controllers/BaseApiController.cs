using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace Api.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public abstract class BaseApiController : ControllerBase
{
    private IMediator? _mediator;

    protected IMediator Mediator;

    public BaseApiController()
    {
        Mediator = _mediator ??= HttpContext.RequestServices.GetRequiredService<IMediator>();
    }
}
