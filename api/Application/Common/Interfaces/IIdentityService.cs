using Api.Application.Common.Models;
using Api.Domain.Entities.Identity;

namespace Api.Application.Common.Interfaces;

public interface IIdentityService
{
    Task<AppUser?> GetUserAsync(string? email);
    Task<AppUser?> GetUserByIdAsync(string? id);

    Task<string?> GetUserNameAsync(string userId);

    Task<bool> CheckPasswordAsync(AppUser user, string? password);

    Task<string?> GetUserRoleAsync(AppUser user);
    Task<bool> IsInRoleAsync(string userId, string role);

    Task<bool> AuthorizeAsync(string userId, string policyName);

    Task<(Result<bool> Result, string UserId)> CreateUserAsync(string userName, string password);

    Task<Result<bool>> DeleteUserAsync(string userId);
}
