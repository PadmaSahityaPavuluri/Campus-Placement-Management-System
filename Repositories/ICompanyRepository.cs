using Campus_Placement_Management_System.Models;

namespace Campus_Placement_Management_System.Repositories;

public interface ICompanyRepository
{
    Task<IEnumerable<Company>> GetAllCompaniesAsync();

    Task<Company?> GetCompanyByIdAsync(int id);

    Task<Company> AddCompanyAsync(Company company);

    Task<Company?> UpdateCompanyAsync(Company company);

    Task<bool> DeleteCompanyAsync(int id);
}
