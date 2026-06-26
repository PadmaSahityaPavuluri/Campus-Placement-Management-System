using Campus_Placement_Management_System.DTOs;
using Campus_Placement_Management_System.Models;
using Campus_Placement_Management_System.Repositories;

namespace Campus_Placement_Management_System.Services;

public class CompanyService : ICompanyService
{
    private readonly ICompanyRepository _companyRepository;

    public CompanyService(ICompanyRepository companyRepository)
    {
        _companyRepository = companyRepository;
    }

    public async Task<IEnumerable<CompanyResponseDto>> GetAllCompaniesAsync()
    {
        var companies = await _companyRepository.GetAllCompaniesAsync();

        return companies.Select(c => new CompanyResponseDto
        {
            CompanyId = c.CompanyId,
            CompanyName = c.CompanyName,
            Package = c.Package,
            MinCGPA = c.MinCGPA,
            Description = c.Description,
            EligibleBranches = c.EligibleBranches
        });
    }

    public async Task<CompanyResponseDto?> GetCompanyByIdAsync(int id)
    {
        var company = await _companyRepository.GetCompanyByIdAsync(id);

        if (company == null)
            return null;

        return new CompanyResponseDto
        {
            CompanyId = company.CompanyId,
            CompanyName = company.CompanyName,
            Package = company.Package,
            MinCGPA = company.MinCGPA,
            Description = company.Description,
            EligibleBranches = company.EligibleBranches
        };
    }

    public async Task<CompanyResponseDto> AddCompanyAsync(CreateCompanyDto dto)
    {
        var company = new Company
        {
            CompanyName = dto.CompanyName,
            Package = dto.Package,
            MinCGPA = dto.MinCGPA,
            Description = dto.Description,
            EligibleBranches = dto.EligibleBranches
        };

        var created = await _companyRepository.AddCompanyAsync(company);

        return new CompanyResponseDto
        {
            CompanyId = created.CompanyId,
            CompanyName = created.CompanyName,
            Package = created.Package,
            MinCGPA = created.MinCGPA,
            Description = created.Description,
            EligibleBranches = created.EligibleBranches
        };
    }

    public async Task<CompanyResponseDto?> UpdateCompanyAsync(int id, UpdateCompanyDto dto)
    {
        var company = await _companyRepository.GetCompanyByIdAsync(id);

        if (company == null)
            return null;

        company.CompanyName = dto.CompanyName;
        company.Package = dto.Package;
        company.MinCGPA = dto.MinCGPA;
        company.Description = dto.Description;
        company.EligibleBranches = dto.EligibleBranches;

        var updated = await _companyRepository.UpdateCompanyAsync(company);

        if (updated == null)
            return null;

        return new CompanyResponseDto
        {
            CompanyId = updated.CompanyId,
            CompanyName = updated.CompanyName,
            Package = updated.Package,
            MinCGPA = updated.MinCGPA,
            Description = updated.Description,
            EligibleBranches = updated.EligibleBranches
        };
    }

    public async Task<bool> DeleteCompanyAsync(int id)
    {
        return await _companyRepository.DeleteCompanyAsync(id);
    }
}