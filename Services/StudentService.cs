using Campus_Placement_Management_System.DTOs;
using Campus_Placement_Management_System.Models;
using Campus_Placement_Management_System.Repositories;

namespace Campus_Placement_Management_System.Services;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _studentRepository;

    public StudentService(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public async Task<IEnumerable<StudentResponseDto>> GetAllStudentsAsync()
    {
        var students = await _studentRepository.GetAllStudentsAsync();

        return students.Select(s => new StudentResponseDto
        {
            StudentId = s.StudentId,
            RollNo = s.RollNo,
            Branch = s.Branch,
            CGPA = s.CGPA,
            Skills = s.Skills,
            ResumePath = s.ResumePath,
            Phone = s.Phone,
            UserName = s.User?.Name ?? "",
            Email = s.User?.Email ?? ""
        });
    }

    public async Task<StudentResponseDto?> GetStudentByIdAsync(int id)
    {
        var s = await _studentRepository.GetStudentByIdAsync(id);

        if (s == null)
            return null;

        return new StudentResponseDto
        {
            StudentId = s.StudentId,
            RollNo = s.RollNo,
            Branch = s.Branch,
            CGPA = s.CGPA,
            Skills = s.Skills,
            ResumePath = s.ResumePath,
            Phone = s.Phone,
            UserName = s.User?.Name ?? "",
            Email = s.User?.Email ?? ""
        };
    }

    public async Task<StudentResponseDto> AddStudentAsync(CreateStudentDto dto)
    {
        var student = new Student
        {
            UserId = dto.UserId,
            RollNo = dto.RollNo,
            Branch = dto.Branch,
            CGPA = dto.CGPA,
            Skills = dto.Skills,
            Phone = dto.Phone
        };

        var created = await _studentRepository.AddStudentAsync(student);

        return new StudentResponseDto
        {
            StudentId = created.StudentId,
            RollNo = created.RollNo,
            Branch = created.Branch,
            CGPA = created.CGPA,
            Skills = created.Skills,
            ResumePath = created.ResumePath,
            Phone = created.Phone,
            UserName = created.User?.Name ?? "",
            Email = created.User?.Email ?? ""
        };
    }

    public async Task<StudentResponseDto?> UpdateStudentAsync(int id, UpdateStudentDto dto)
    {
        var student = await _studentRepository.GetStudentByIdAsync(id);

        if (student == null)
            return null;

        student.RollNo = dto.RollNo;
        student.Branch = dto.Branch;
        student.CGPA = dto.CGPA;
        student.Skills = dto.Skills;
        student.Phone = dto.Phone;

        var updated = await _studentRepository.UpdateStudentAsync(student);

        if (updated == null)
            return null;

        return new StudentResponseDto
        {
            StudentId = updated.StudentId,
            RollNo = updated.RollNo,
            Branch = updated.Branch,
            CGPA = updated.CGPA,
            Skills = updated.Skills,
            ResumePath = updated.ResumePath,
            Phone = updated.Phone,
            UserName = updated.User?.Name ?? "",
            Email = updated.User?.Email ?? ""
        };
    }

    public async Task<bool> DeleteStudentAsync(int id)
    {
        return await _studentRepository.DeleteStudentAsync(id);
    }
}