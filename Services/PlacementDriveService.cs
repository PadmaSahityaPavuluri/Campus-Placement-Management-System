using Campus_Placement_Management_System.DTOs;
using Campus_Placement_Management_System.Models;
using Campus_Placement_Management_System.Repositories;

namespace Campus_Placement_Management_System.Services;

public class PlacementDriveService : IPlacementDriveService
{
    private readonly IPlacementDriveRepository _repository;

    public PlacementDriveService(IPlacementDriveRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<PlacementDriveResponseDto>> GetAllPlacementDrivesAsync()
    {
        var drives = await _repository.GetAllPlacementDrivesAsync();

        return drives.Select(d => new PlacementDriveResponseDto
        {
            DriveId = d.DriveId,
            CompanyId = d.CompanyId,
            CompanyName = d.Company?.CompanyName ?? "",
            DriveDate = d.DriveDate,
            RegistrationDeadline = d.RegistrationDeadline,
            Location = d.Location
        });
    }

    public async Task<PlacementDriveResponseDto?> GetPlacementDriveByIdAsync(int id)
    {
        var drive = await _repository.GetPlacementDriveByIdAsync(id);

        if (drive == null)
            return null;

        return new PlacementDriveResponseDto
        {
            DriveId = drive.DriveId,
            CompanyId = drive.CompanyId,
            CompanyName = drive.Company?.CompanyName ?? "",
            DriveDate = drive.DriveDate,
            RegistrationDeadline = drive.RegistrationDeadline,
            Location = drive.Location
        };
    }

    public async Task<PlacementDriveResponseDto> AddPlacementDriveAsync(CreatePlacementDriveDto dto)
    {
        var drive = new PlacementDrive
        {
            CompanyId = dto.CompanyId,
            DriveDate = dto.DriveDate,
            RegistrationDeadline = dto.RegistrationDeadline,
            Location = dto.Location
        };

        var created = await _repository.AddPlacementDriveAsync(drive);

        return new PlacementDriveResponseDto
        {
            DriveId = created.DriveId,
            CompanyId = created.CompanyId,
            CompanyName = created.Company?.CompanyName ?? "",
            DriveDate = created.DriveDate,
            RegistrationDeadline = created.RegistrationDeadline,
            Location = created.Location
        };
    }

    public async Task<PlacementDriveResponseDto?> UpdatePlacementDriveAsync(int id, UpdatePlacementDriveDto dto)
    {
        var drive = await _repository.GetPlacementDriveByIdAsync(id);

        if (drive == null)
            return null;

        drive.CompanyId = dto.CompanyId;
        drive.DriveDate = dto.DriveDate;
        drive.RegistrationDeadline = dto.RegistrationDeadline;
        drive.Location = dto.Location;

        var updated = await _repository.UpdatePlacementDriveAsync(drive);

        if (updated == null)
            return null;

        return new PlacementDriveResponseDto
        {
            DriveId = updated.DriveId,
            CompanyId = updated.CompanyId,
            CompanyName = updated.Company?.CompanyName ?? "",
            DriveDate = updated.DriveDate,
            RegistrationDeadline = updated.RegistrationDeadline,
            Location = updated.Location
        };
    }

    public async Task<bool> DeletePlacementDriveAsync(int id)
    {
        return await _repository.DeletePlacementDriveAsync(id);
    }
}