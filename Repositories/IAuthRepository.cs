using Campus_Placement_Management_System.DTOs;
using Campus_Placement_Management_System.Models;

namespace Campus_Placement_Management_System.Repositories;

public interface IAuthRepository
{
    Task<User?> Register(RegisterDto registerDto);
    Task<User?> Login(LoginDto loginDto);
    Task<bool> UserExists(string email);
}