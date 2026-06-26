using Campus_Placement_Management_System.Data;
using Campus_Placement_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Campus_Placement_Management_System.Repositories;

public class ApplicationRepository : IApplicationRepository
{
    private readonly ApplicationDbContext _context;

    public ApplicationRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Application>> GetAllApplicationsAsync()
    {
        return await _context.Applications
            .Include(a => a.Student)
                .ThenInclude(s => s.User)
            .Include(a => a.PlacementDrive)
                .ThenInclude(d => d.Company)
            .ToListAsync();
    }

    public async Task<Application?> GetApplicationByIdAsync(int id)
    {
        return await _context.Applications
            .Include(a => a.Student)
                .ThenInclude(s => s.User)
            .Include(a => a.PlacementDrive)
                .ThenInclude(d => d.Company)
            .FirstOrDefaultAsync(a => a.ApplicationId == id);
    }

    public async Task<Application> AddApplicationAsync(Application application)
    {
        _context.Applications.Add(application);
        await _context.SaveChangesAsync();

        return await _context.Applications
            .Include(a => a.Student)
                .ThenInclude(s => s.User)
            .Include(a => a.PlacementDrive)
                .ThenInclude(d => d.Company)
            .FirstAsync(a => a.ApplicationId == application.ApplicationId);
    }

    public async Task<Application?> UpdateApplicationAsync(Application application)
    {
        var existing = await _context.Applications.FindAsync(application.ApplicationId);

        if (existing == null)
            return null;

        existing.Status = application.Status;

        await _context.SaveChangesAsync();

        return await _context.Applications
            .Include(a => a.Student)
                .ThenInclude(s => s.User)
            .Include(a => a.PlacementDrive)
                .ThenInclude(d => d.Company)
            .FirstAsync(a => a.ApplicationId == application.ApplicationId);
    }

    public async Task<bool> DeleteApplicationAsync(int id)
    {
        var application = await _context.Applications.FindAsync(id);

        if (application == null)
            return false;

        _context.Applications.Remove(application);
        await _context.SaveChangesAsync();

        return true;
    }
}