namespace Campus_Placement_Management_System.DTOs;

public class ApplicationResponseDto
{
    public int ApplicationId { get; set; }

    public int StudentId { get; set; }

    public string StudentName { get; set; } = string.Empty;

    public int DriveId { get; set; }

    public string CompanyName { get; set; } = string.Empty;

    public string Status { get; set; } = string.Empty;

    public DateTime AppliedDate { get; set; }
}