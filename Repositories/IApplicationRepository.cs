using Campus_Placement_Management_System.Models;

namespace Campus_Placement_Management_System.Repositories;

public interface IApplicationRepository
{
    Task<IEnumerable<Application>> GetAllApplicationsAsync();

    Task<Application?> GetApplicationByIdAsync(int id);

    Task<Application> AddApplicationAsync(Application application);

    Task<Application?> UpdateApplicationAsync(Application application);

    Task<bool> DeleteApplicationAsync(int id);
}