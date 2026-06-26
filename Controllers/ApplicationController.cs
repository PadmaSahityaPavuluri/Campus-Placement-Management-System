using Campus_Placement_Management_System.DTOs;
using Campus_Placement_Management_System.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Campus_Placement_Management_System.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class ApplicationController : ControllerBase
{
    private readonly IApplicationService _service;

    public ApplicationController(IApplicationService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllApplications()
    {
        return Ok(await _service.GetAllApplicationsAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetApplicationById(int id)
    {
        var application = await _service.GetApplicationByIdAsync(id);

        if (application == null)
            return NotFound("Application not found.");

        return Ok(application);
    }

    [HttpPost]
    public async Task<IActionResult> AddApplication(CreateApplicationDto dto)
    {
        var application = await _service.AddApplicationAsync(dto);

        return CreatedAtAction(
            nameof(GetApplicationById),
            new { id = application.ApplicationId },
            application);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateApplication(int id, UpdateApplicationDto dto)
    {
        var application = await _service.UpdateApplicationAsync(id, dto);

        if (application == null)
            return NotFound("Application not found.");

        return Ok(application);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteApplication(int id)
    {
        var deleted = await _service.DeleteApplicationAsync(id);

        if (!deleted)
            return NotFound("Application not found.");

        return Ok("Application deleted successfully.");
    }
}