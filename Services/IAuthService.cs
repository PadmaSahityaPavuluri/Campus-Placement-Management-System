using Campus_Placement_Management_System.DTOs;

namespace Campus_Placement_Management_System.Services;

public interface IAuthService
{
    Task<string?> Register(RegisterDto registerDto);
    Task<string?> Login(LoginDto loginDto);
}