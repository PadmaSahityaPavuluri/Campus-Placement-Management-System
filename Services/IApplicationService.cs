using Campus_Placement_Management_System.DTOs;

namespace Campus_Placement_Management_System.Services;

public interface IApplicationService
{
    Task<IEnumerable<ApplicationResponseDto>> GetAllApplicationsAsync();

    Task<ApplicationResponseDto?> GetApplicationByIdAsync(int id);

    Task<ApplicationResponseDto> AddApplicationAsync(CreateApplicationDto dto);

    Task<ApplicationResponseDto?> UpdateApplicationAsync(int id, UpdateApplicationDto dto);

    Task<bool> DeleteApplicationAsync(int id);
}