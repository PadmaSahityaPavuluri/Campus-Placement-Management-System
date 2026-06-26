using System.ComponentModel.DataAnnotations;

namespace Campus_Placement_Management_System.DTOs;

public class UpdateApplicationDto
{
    [Required]
    public string Status { get; set; } = string.Empty;
}