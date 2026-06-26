using Campus_Placement_Management_System.DTOs;

namespace Campus_Placement_Management_System.Services;

public interface IPlacementDriveService
{
    Task<IEnumerable<PlacementDriveResponseDto>> GetAllPlacementDrivesAsync();

    Task<PlacementDriveResponseDto?> GetPlacementDriveByIdAsync(int id);

    Task<PlacementDriveResponseDto> AddPlacementDriveAsync(CreatePlacementDriveDto dto);

    Task<PlacementDriveResponseDto?> UpdatePlacementDriveAsync(int id, UpdatePlacementDriveDto dto);

    Task<bool> DeletePlacementDriveAsync(int id);
}