using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StockDashboardAPI.Data;
using StockDashboardAPI.Models;
using System.Text.Json;

namespace StockDashboardAPI.Controllers
{
    public class CompanyOverviewsController : Controller
    {
        private const string V = "gitev";
        private readonly AppDbContext _context;

        public CompanyOverviewsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet(V)]
        public async Task<List<CompanyOverview>> GetAllCompanyOverviews()
        {
            return await _context.CompanyOverview.ToListAsync();
        }
                                                                                                                                                              
        [HttpPost("savecompany")]
        public async Task<IActionResult> SaveCompany([FromBody] CompanyOverview company)
        {
            if (company == null)
            {
                return BadRequest("Invalid company data.");
            }
            _context.CompanyOverview.Add(company);
            await _context.SaveChangesAsync();
            Console.WriteLine("Sucess");
            return CreatedAtAction(nameof(SaveCompany), new { id = company.Id }, company);
        }

        [HttpGet("GetSearch")]
        public async Task<IActionResult> GetSearch()
        {
            var companyOverviews = await GetAllCompanyOverviews();
            return Json(companyOverviews);
        }


    }
}

