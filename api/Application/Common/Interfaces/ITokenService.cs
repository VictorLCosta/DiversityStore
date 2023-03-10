using Api.Domain.Entities.Identity;

namespace Api.Application.Common.Interfaces;

public interface ITokenService
{
    string GenerateJwtToken(AppUser user);
}
