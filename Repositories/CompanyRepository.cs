using Campus_Placement_Management_System.Data;
using Campus_Placement_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Campus_Placement_Management_System.Repositories;

public class CompanyRepository : ICompanyRepository
{
    private readonly ApplicationDbContext _context;

    public CompanyRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Company>> GetAllCompaniesAsync()
    {
        return await _context.Companies.ToListAsync();
    }

    public async Task<Company?> GetCompanyByIdAsync(int id)
    {
        return await _context.Companies
            .FirstOrDefaultAsync(c => c.CompanyId == id);
    }

    public async Task<Company> AddCompanyAsync(Company company)
    {
        _context.Companies.Add(company);
        await _context.SaveChangesAsync();
        return company;
    }

    public async Task<Company?> UpdateCompanyAsync(Company company)
    {
        var existing = await _context.Companies.FindAsync(company.CompanyId);

        if (existing == null)
            return null;

        existing.CompanyName = company.CompanyName;
        existing.Package = company.Package;
        existing.MinCGPA = company.MinCGPA;
        existing.Description = company.Description;
        existing.EligibleBranches = company.EligibleBranches;

        await _context.SaveChangesAsync();

        return existing;
    }

    public async Task<bool> DeleteCompanyAsync(int id)
    {
        var company = await _context.Companies.FindAsync(id);

        if (company == null)
            return false;

        _context.Companies.Remove(company);

        await _context.SaveChangesAsync();

        return true;
    }
}
