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


        public async Task<IActionResult> OverviewI(string symbol) // Assuming you want to fetch data by a stock symbol
        {
            // Fetch the data from your database (or however you populate the model)
            var companyOverview = await _context.CompanyOverview.FirstOrDefaultAsync(c => c.Symbol == symbol);

            // Pass it to the view
            return View(companyOverview);

        }

        [HttpPost]
        public async Task<IActionResult> SaveCo(CompanyOverview model)
        {
            // Here you'd save the provided model to your database
            // This is just a simplistic example. You'd likely want to do checks, handle updates vs. new entries, etc.
            _context.Add(model);
            await _context.SaveChangesAsync();

            return RedirectToAction("Overview");
        }

    }
}

