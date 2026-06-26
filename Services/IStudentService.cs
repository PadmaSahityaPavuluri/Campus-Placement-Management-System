using Campus_Placement_Management_System.DTOs;

namespace Campus_Placement_Management_System.Services;

public interface IStudentService
{
    Task<IEnumerable<StudentResponseDto>> GetAllStudentsAsync();

    Task<StudentResponseDto?> GetStudentByIdAsync(int id);

    Task<StudentResponseDto> AddStudentAsync(CreateStudentDto dto);

    Task<StudentResponseDto?> UpdateStudentAsync(int id, UpdateStudentDto dto);

    Task<bool> DeleteStudentAsync(int id);
}