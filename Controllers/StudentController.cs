using Microsoft.AspNetCore.Authorization;
using Campus_Placement_Management_System.DTOs;
using Campus_Placement_Management_System.Services;
using Microsoft.AspNetCore.Mvc;

namespace Campus_Placement_Management_System.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class StudentController : ControllerBase
{
    private readonly IStudentService _studentService;

    public StudentController(IStudentService studentService)
    {
        _studentService = studentService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllStudents()
    {
        var students = await _studentService.GetAllStudentsAsync();
        return Ok(students);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetStudentById(int id)
    {
        var student = await _studentService.GetStudentByIdAsync(id);

        if (student == null)
            return NotFound("Student not found.");

        return Ok(student);
    }

    [HttpPost]
    public async Task<IActionResult> AddStudent(CreateStudentDto dto)
    {
        var student = await _studentService.AddStudentAsync(dto);

        return CreatedAtAction(
            nameof(GetStudentById),
            new { id = student.StudentId },
            student);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateStudent(
        int id,
        UpdateStudentDto dto)
    {
        var student = await _studentService.UpdateStudentAsync(id, dto);

        if (student == null)
            return NotFound("Student not found.");

        return Ok(student);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteStudent(int id)
    {
        var deleted = await _studentService.DeleteStudentAsync(id);

        if (!deleted)
            return NotFound("Student not found.");

        return Ok("Student deleted successfully.");
    }
}