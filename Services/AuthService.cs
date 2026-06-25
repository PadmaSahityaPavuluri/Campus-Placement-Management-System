using Campus_Placement_Management_System.DTOs;
using Campus_Placement_Management_System.Helpers;
using Campus_Placement_Management_System.Repositories;

namespace Campus_Placement_Management_System.Services;

public class AuthService : IAuthService
{
    private readonly IAuthRepository _authRepository;
    private readonly JwtHelper _jwtHelper;

    public AuthService(
        IAuthRepository authRepository,
        JwtHelper jwtHelper)
    {
        _authRepository = authRepository;
        _jwtHelper = jwtHelper;
    }

    public async Task<string?> Register(RegisterDto registerDto)
    {
        var user = await _authRepository.Register(registerDto);

        if (user == null)
            return null;

        return "User Registered Successfully";
    }

    public async Task<string?> Login(LoginDto loginDto)
    {
        var user = await _authRepository.Login(loginDto);

        if (user == null)
            return null;

        return _jwtHelper.GenerateToken(user);
    }
}