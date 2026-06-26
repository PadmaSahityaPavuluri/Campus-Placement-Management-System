namespace Campus_Placement_Management_System.DTOs;

public class CompanyResponseDto
{
    public int CompanyId { get; set; }

    public string CompanyName { get; set; } = string.Empty;

    public decimal Package { get; set; }

    public decimal MinCGPA { get; set; }

    public string Description { get; set; } = string.Empty;

    public string EligibleBranches { get; set; } = string.Empty;
}