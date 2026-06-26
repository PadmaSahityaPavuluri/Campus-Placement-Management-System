using Campus_Placement_Management_System.DTOs;
using Campus_Placement_Management_System.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Campus_Placement_Management_System.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class CompanyController : ControllerBase
{
    private readonly ICompanyService _companyService;

    public CompanyController(ICompanyService companyService)
    {
        _companyService = companyService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCompanies()
    {
        return Ok(await _companyService.GetAllCompaniesAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCompanyById(int id)
    {
        var company = await _companyService.GetCompanyByIdAsync(id);

        if (company == null)
            return NotFound("Company not found.");

        return Ok(company);
    }

    [HttpPost]
    public async Task<IActionResult> AddCompany(CreateCompanyDto dto)
    {
        var company = await _companyService.AddCompanyAsync(dto);

        return CreatedAtAction(
            nameof(GetCompanyById),
            new { id = company.CompanyId },
            company);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCompany(int id, UpdateCompanyDto dto)
    {
        var company = await _companyService.UpdateCompanyAsync(id, dto);

        if (company == null)
            return NotFound("Company not found.");

        return Ok(company);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCompany(int id)
    {
        var deleted = await _companyService.DeleteCompanyAsync(id);

        if (!deleted)
            return NotFound("Company not found.");

        return Ok("Company deleted successfully.");
    }
}