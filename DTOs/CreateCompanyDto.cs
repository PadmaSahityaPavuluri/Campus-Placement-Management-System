using System.ComponentModel.DataAnnotations;

namespace Campus_Placement_Management_System.DTOs;

public class CreateCompanyDto
{
    [Required]
    public string CompanyName { get; set; } = string.Empty;

    [Required]
    public decimal Package { get; set; }

    [Required]
    public decimal MinCGPA { get; set; }

    public string Description { get; set; } = string.Empty;

    public string EligibleBranches { get; set; } = string.Empty;
}