using Campus_Placement_Management_System.DTOs;
using Campus_Placement_Management_System.Services;
using Microsoft.AspNetCore.Mvc;

namespace Campus_Placement_Management_System.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto dto)
    {
        var result = await _authService.Register(dto);

        if (result == null)
            return BadRequest("Email already exists.");

        return Ok(result);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto dto)
    {
        var token = await _authService.Login(dto);

        if (token == null)
            return Unauthorized("Invalid email or password.");

        return Ok(new { Token = token });
    }
}