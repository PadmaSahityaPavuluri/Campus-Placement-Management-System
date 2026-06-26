using Campus_Placement_Management_System.Data;
using Campus_Placement_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Campus_Placement_Management_System.Repositories;

public class PlacementDriveRepository : IPlacementDriveRepository
{
    private readonly ApplicationDbContext _context;

    public PlacementDriveRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<PlacementDrive>> GetAllPlacementDrivesAsync()
    {
        return await _context.PlacementDrives
            .Include(d => d.Company)
            .ToListAsync();
    }

    public async Task<PlacementDrive?> GetPlacementDriveByIdAsync(int id)
    {
        return await _context.PlacementDrives
            .Include(d => d.Company)
            .FirstOrDefaultAsync(d => d.DriveId == id);
    }

    public async Task<PlacementDrive> AddPlacementDriveAsync(PlacementDrive drive)
    {
        _context.PlacementDrives.Add(drive);
        await _context.SaveChangesAsync();

        return await _context.PlacementDrives
            .Include(d => d.Company)
            .FirstAsync(d => d.DriveId == drive.DriveId);
    }

    public async Task<PlacementDrive?> UpdatePlacementDriveAsync(PlacementDrive drive)
    {
        var existing = await _context.PlacementDrives.FindAsync(drive.DriveId);

        if (existing == null)
            return null;

        existing.CompanyId = drive.CompanyId;
        existing.DriveDate = drive.DriveDate;
        existing.RegistrationDeadline = drive.RegistrationDeadline;
        existing.Location = drive.Location;

        await _context.SaveChangesAsync();

        return existing;
    }

    public async Task<bool> DeletePlacementDriveAsync(int id)
    {
        var drive = await _context.PlacementDrives.FindAsync(id);

        if (drive == null)
            return false;

        _context.PlacementDrives.Remove(drive);

        await _context.SaveChangesAsync();

        return true;
    }
}