namespace Campus_Placement_Management_System.DTOs;

public class StudentResponseDto
{
    public int StudentId { get; set; }

    public string RollNo { get; set; } = string.Empty;

    public string Branch { get; set; } = string.Empty;

    public decimal CGPA { get; set; }

    public string Skills { get; set; } = string.Empty;

    public string? ResumePath { get; set; }

    public string Phone { get; set; } = string.Empty;

    public string UserName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;
}