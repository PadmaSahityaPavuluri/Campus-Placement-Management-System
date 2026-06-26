using Campus_Placement_Management_System.DTOs;
using Campus_Placement_Management_System.Models;
using Campus_Placement_Management_System.Repositories;

namespace Campus_Placement_Management_System.Services;

public class ApplicationService : IApplicationService
{
    private readonly IApplicationRepository _repository;

    public ApplicationService(IApplicationRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<ApplicationResponseDto>> GetAllApplicationsAsync()
    {
        var applications = await _repository.GetAllApplicationsAsync();

        return applications.Select(a => new ApplicationResponseDto
        {
            ApplicationId = a.ApplicationId,
            StudentId = a.StudentId,
            StudentName = a.Student?.User?.Name ?? "",
            DriveId = a.DriveId,
            CompanyName = a.PlacementDrive?.Company?.CompanyName ?? "",
            Status = a.Status,
            AppliedDate = a.AppliedDate
        });
    }

    public async Task<ApplicationResponseDto?> GetApplicationByIdAsync(int id)
    {
        var application = await _repository.GetApplicationByIdAsync(id);

        if (application == null)
            return null;

        return new ApplicationResponseDto
        {
            ApplicationId = application.ApplicationId,
            StudentId = application.StudentId,
            StudentName = application.Student?.User?.Name ?? "",
            DriveId = application.DriveId,
            CompanyName = application.PlacementDrive?.Company?.CompanyName ?? "",
            Status = application.Status,
            AppliedDate = application.AppliedDate
        };
    }

    public async Task<ApplicationResponseDto> AddApplicationAsync(CreateApplicationDto dto)
    {
        var application = new Application
        {
            StudentId = dto.StudentId,
            DriveId = dto.DriveId,
            Status = "Pending",
            AppliedDate = DateTime.UtcNow
        };

        var created = await _repository.AddApplicationAsync(application);

        return new ApplicationResponseDto
        {
            ApplicationId = created.ApplicationId,
            StudentId = created.StudentId,
            StudentName = created.Student?.User?.Name ?? "",
            DriveId = created.DriveId,
            CompanyName = created.PlacementDrive?.Company?.CompanyName ?? "",
            Status = created.Status,
            AppliedDate = created.AppliedDate
        };
    }

    public async Task<ApplicationResponseDto?> UpdateApplicationAsync(int id, UpdateApplicationDto dto)
    {
        var application = await _repository.GetApplicationByIdAsync(id);

        if (application == null)
            return null;

        application.Status = dto.Status;

        var updated = await _repository.UpdateApplicationAsync(application);

        if (updated == null)
            return null;

        return new ApplicationResponseDto
        {
            ApplicationId = updated.ApplicationId,
            StudentId = updated.StudentId,
            StudentName = updated.Student?.User?.Name ?? "",
            DriveId = updated.DriveId,
            CompanyName = updated.PlacementDrive?.Company?.CompanyName ?? "",
            Status = updated.Status,
            AppliedDate = updated.AppliedDate
        };
    }

    public async Task<bool> DeleteApplicationAsync(int id)
    {
        return await _repository.DeleteApplicationAsync(id);
    }
}