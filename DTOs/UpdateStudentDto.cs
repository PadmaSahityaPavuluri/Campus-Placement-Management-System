using System.ComponentModel.DataAnnotations;

namespace Campus_Placement_Management_System.DTOs;

public class UpdateStudentDto
{
    [Required]
    public string RollNo { get; set; } = string.Empty;

    [Required]
    public string Branch { get; set; } = string.Empty;

    [Required]
    public decimal CGPA { get; set; }

    public string Skills { get; set; } = string.Empty;

    public string Phone { get; set; } = string.Empty;
}