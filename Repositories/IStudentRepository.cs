using Campus_Placement_Management_System.Models;

namespace Campus_Placement_Management_System.Repositories;

public interface IStudentRepository
{
    Task<IEnumerable<Student>> GetAllStudentsAsync();

    Task<Student?> GetStudentByIdAsync(int id);

    Task<Student> AddStudentAsync(Student student);

    Task<Student?> UpdateStudentAsync(Student student);

    Task<bool> DeleteStudentAsync(int id);
}