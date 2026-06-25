using System.ComponentModel.DataAnnotations;

namespace Campus_Placement_Management_System.Models;

public class PlacementDrive
{
    [Key]
    public int DriveId { get; set; }

    public int CompanyId { get; set; }

    public DateTime DriveDate { get; set; }

    public DateTime RegistrationDeadline { get; set; }

    public string Location { get; set; } = string.Empty;

    public Company? Company { get; set; }
}