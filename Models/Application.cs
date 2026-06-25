using System.ComponentModel.DataAnnotations;

namespace Campus_Placement_Management_System.Models;

public class Application
{
    [Key]
    public int ApplicationId { get; set; }

    public int StudentId { get; set; }

    public int DriveId { get; set; }

    public string Status { get; set; } = "Pending";

    public DateTime AppliedDate { get; set; }

    public Student? Student { get; set; }

    public PlacementDrive? PlacementDrive { get; set; }
}