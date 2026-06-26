namespace Campus_Placement_Management_System.DTOs;

public class PlacementDriveResponseDto
{
    public int DriveId { get; set; }

    public int CompanyId { get; set; }

    public string CompanyName { get; set; } = string.Empty;

    public DateTime DriveDate { get; set; }

    public DateTime RegistrationDeadline { get; set; }

    public string Location { get; set; } = string.Empty;
}