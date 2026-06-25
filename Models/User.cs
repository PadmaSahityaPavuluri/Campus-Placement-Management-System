using System.ComponentModel.DataAnnotations;

namespace Campus_Placement_Management_System.Models;

public class User
{
    [Key]
    public int UserId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string PasswordHash { get; set; } = string.Empty;

    public int RoleId { get; set; }

    public Role? Role { get; set; }
}