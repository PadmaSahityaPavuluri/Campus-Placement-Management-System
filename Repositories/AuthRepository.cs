using BCrypt.Net;
using Campus_Placement_Management_System.Data;
using Campus_Placement_Management_System.DTOs;
using Campus_Placement_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Campus_Placement_Management_System.Repositories;

public class AuthRepository : IAuthRepository
{
    private readonly ApplicationDbContext _context;

    public AuthRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> UserExists(string email)
    {
        return await _context.Users.AnyAsync(x => x.Email == email);
    }

    public async Task<User?> Register(RegisterDto registerDto)
    {
        if (await UserExists(registerDto.Email))
            return null;

        var user = new User
        {
            Name = registerDto.Name,
            Email = registerDto.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(registerDto.Password),
            RoleId = registerDto.RoleId
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return user;
    }

    public async Task<User?> Login(LoginDto loginDto)
    {
        var user = await _context.Users
            .Include(u => u.Role)
            .FirstOrDefaultAsync(u => u.Email == loginDto.Email);

        if (user == null)
            return null;

        bool validPassword = BCrypt.Net.BCrypt.Verify(
            loginDto.Password,
            user.PasswordHash);

        if (!validPassword)
            return null;

        return user;
    }
}