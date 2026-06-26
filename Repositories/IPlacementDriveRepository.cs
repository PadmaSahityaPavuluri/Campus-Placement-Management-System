using Campus_Placement_Management_System.Models;

namespace Campus_Placement_Management_System.Repositories;

public interface IPlacementDriveRepository
{
    Task<IEnumerable<PlacementDrive>> GetAllPlacementDrivesAsync();

    Task<PlacementDrive?> GetPlacementDriveByIdAsync(int id);

    Task<PlacementDrive> AddPlacementDriveAsync(PlacementDrive drive);

    Task<PlacementDrive?> UpdatePlacementDriveAsync(PlacementDrive drive);

    Task<bool> DeletePlacementDriveAsync(int id);
}