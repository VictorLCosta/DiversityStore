using Api.Application.Common.Interfaces;
using Api.Web.Models;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Web.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly ICurrentUserService _currentUserService;
    private readonly IIdentityService _identityService;
    private readonly ITokenService _tokenService;

    public AuthController(
        ICurrentUserService currentUserService,
        IIdentityService identityService,
        ITokenService tokenService)
    {
        _currentUserService = currentUserService;
        _identityService = identityService;
        _tokenService = tokenService;
    }

    [HttpGet("me")]
    public async Task<IActionResult> Me()
    {
        var currentUserId = _currentUserService.UserId;

        var user = await _identityService.GetUserByIdAsync(currentUserId);

        if (user != null) return Ok(new AuthUser
        {
            Id = user.Id,
            Email = user.Email,
            DisplayName = user.DisplayName,
            UserName = user.UserName
        });

        return NotFound("User not found");
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto loginDto)
    {
        var user = await _identityService.GetUserAsync(loginDto.Email);

        if (user == null) return Unauthorized();

        var result = await _identityService.CheckPasswordAsync(user, loginDto.Password);

        if (result)
        {
            var role = await _identityService.GetUserRoleAsync(user);

            var token = _tokenService.GenerateJwtToken(user, role);

            return Ok(new UserResponseDto
            {
                Token = token,
                AuthUser = new AuthUser
                {
                    Id = user.Id,
                    Email = user.Email,
                    DisplayName = user.DisplayName,
                    UserName = user.UserName,
                }
            });
        }

        return Unauthorized();

    }
    
}
