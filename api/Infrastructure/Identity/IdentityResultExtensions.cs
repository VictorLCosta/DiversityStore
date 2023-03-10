using Api.Application.Common.Models;

using Microsoft.AspNetCore.Identity;

namespace Api.Infrastructure.Identity;

public static class IdentityResultExtensions
{
    public static Result<bool> ToApplicationResult(this IdentityResult result)
    {
        return result.Succeeded
            ? Result<bool>.Success(true)
            : Result<bool>.Failure(result.Errors.Select(e => e.Description).Aggregate((current, next) => current + "\n" + next));
    }
}
