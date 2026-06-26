using Campus_Placement_Management_System.DTOs;

namespace Campus_Placement_Management_System.Services;

public interface ICompanyService
{
    Task<IEnumerable<CompanyResponseDto>> GetAllCompaniesAsync();

    Task<CompanyResponseDto?> GetCompanyByIdAsync(int id);

    Task<CompanyResponseDto> AddCompanyAsync(CreateCompanyDto dto);

    Task<CompanyResponseDto?> UpdateCompanyAsync(int id, UpdateCompanyDto dto);

    Task<bool> DeleteCompanyAsync(int id);
}