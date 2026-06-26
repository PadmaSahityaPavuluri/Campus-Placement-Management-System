using System.ComponentModel.DataAnnotations;

namespace Campus_Placement_Management_System.DTOs;

public class CreatePlacementDriveDto
{
    [Required]
    public int CompanyId { get; set; }

    [Required]
    public DateTime DriveDate { get; set; }

    [Required]
    public DateTime RegistrationDeadline { get; set; }

    [Required]
    public string Location { get; set; } = string.Empty;
}