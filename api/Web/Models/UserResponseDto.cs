namespace Api.Web.Models;

public class UserResponseDto
{
    public AuthUser? AuthUser { get; set; }
    public string? Token { get; set; }
}
