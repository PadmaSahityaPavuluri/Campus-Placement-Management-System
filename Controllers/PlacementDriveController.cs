using Campus_Placement_Management_System.DTOs;
using Campus_Placement_Management_System.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Campus_Placement_Management_System.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class PlacementDriveController : ControllerBase
{
    private readonly IPlacementDriveService _service;

    public PlacementDriveController(IPlacementDriveService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPlacementDrives()
    {
        return Ok(await _service.GetAllPlacementDrivesAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPlacementDriveById(int id)
    {
        var drive = await _service.GetPlacementDriveByIdAsync(id);

        if (drive == null)
            return NotFound("Placement Drive not found.");

        return Ok(drive);
    }

    [HttpPost]
    public async Task<IActionResult> AddPlacementDrive(CreatePlacementDriveDto dto)
    {
        var drive = await _service.AddPlacementDriveAsync(dto);

        return CreatedAtAction(
            nameof(GetPlacementDriveById),
            new { id = drive.DriveId },
            drive);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePlacementDrive(int id, UpdatePlacementDriveDto dto)
    {
        var drive = await _service.UpdatePlacementDriveAsync(id, dto);

        if (drive == null)
            return NotFound("Placement Drive not found.");

        return Ok(drive);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePlacementDrive(int id)
    {
        var deleted = await _service.DeletePlacementDriveAsync(id);

        if (!deleted)
            return NotFound("Placement Drive not found.");

        return Ok("Placement Drive deleted successfully.");
    }
}