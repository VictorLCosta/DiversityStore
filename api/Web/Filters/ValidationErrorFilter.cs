using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Web.Filters;

public class ValidationErrorFilter : IActionFilter
{
    public void OnActionExecuted(ActionExecutedContext context)
    {
        return;
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.ModelState.IsValid)
        {
            var details = new ValidationProblemDetails(context.ModelState)
            {
                Type = "https://datatracker.ietf.org/doc/html/rfc4918#section-11.2",
            };

            // var details = context.ModelState.Values.SelectMany(x => x.Errors.Select(x => x.ErrorMessage));

            context.Result = new UnprocessableEntityObjectResult(details);
        }
    }
}
