using System.ComponentModel.DataAnnotations;

namespace Campus_Placement_Management_System.DTOs;

public class CreateApplicationDto
{
    [Required]
    public int StudentId { get; set; }

    [Required]
    public int DriveId { get; set; }
}