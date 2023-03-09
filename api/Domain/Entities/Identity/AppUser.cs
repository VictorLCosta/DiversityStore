using Microsoft.AspNetCore.Identity;

namespace Api.Domain.Entities.Identity;

public class AppUser : IdentityUser
{
    public string? DisplayName { get; set; }
}
