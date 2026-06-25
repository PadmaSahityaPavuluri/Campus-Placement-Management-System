using System.ComponentModel.DataAnnotations;

namespace Campus_Placement_Management_System.Models;

public class Student
{
    [Key]
    public int StudentId { get; set; }

    public int UserId { get; set; }

    public string RollNo { get; set; } = string.Empty;

    public string Branch { get; set; } = string.Empty;

    public decimal CGPA { get; set; }

    public string Skills { get; set; } = string.Empty;

    public string? ResumePath { get; set; }

    public string Phone { get; set; } = string.Empty;

    public User? User { get; set; }
}
