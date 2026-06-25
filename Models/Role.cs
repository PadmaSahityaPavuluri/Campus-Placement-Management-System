using System.ComponentModel.DataAnnotations;

namespace Campus_Placement_Management_System.Models;

public class Role
{
    [Key]
    public int RoleId { get; set; }

    public string RoleName { get; set; } = string.Empty;
}