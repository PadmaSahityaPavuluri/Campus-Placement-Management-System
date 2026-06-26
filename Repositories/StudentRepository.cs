using Campus_Placement_Management_System.Data;
using Campus_Placement_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Campus_Placement_Management_System.Repositories;

public class StudentRepository : IStudentRepository
{
    private readonly ApplicationDbContext _context;

    public StudentRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Student>> GetAllStudentsAsync()
    {
        return await _context.Students
            .Include(s => s.User)
            .ToListAsync();
    }

    public async Task<Student?> GetStudentByIdAsync(int id)
    {
        return await _context.Students
            .Include(s => s.User)
            .FirstOrDefaultAsync(s => s.StudentId == id);
    }

    public async Task<Student> AddStudentAsync(Student student)
    {
        _context.Students.Add(student);
        await _context.SaveChangesAsync();
        return student;
    }

    public async Task<Student?> UpdateStudentAsync(Student student)
    {
        var existing = await _context.Students.FindAsync(student.StudentId);

        if (existing == null)
            return null;

        existing.RollNo = student.RollNo;
        existing.Branch = student.Branch;
        existing.CGPA = student.CGPA;
        existing.Skills = student.Skills;
        existing.Phone = student.Phone;
        existing.ResumePath = student.ResumePath;

        await _context.SaveChangesAsync();

        return existing;
    }

    public async Task<bool> DeleteStudentAsync(int id)
    {
        var student = await _context.Students.FindAsync(id);

        if (student == null)
            return false;

        _context.Students.Remove(student);

        await _context.SaveChangesAsync();

        return true;
    }
}
