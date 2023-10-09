using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StockDashboardAPI.Data;
using StockDashboardAPI.Models;
using StockDashboardWeb.Dto;
using StockDashboardWeb.Models;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace StockDashboardWeb.Controllers
{
    public class CompanyOverviewController : Controller
    {

        private readonly AppDbContext _context;  // Assume you have a DbContext for your database

        public CompanyOverviewController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Overview2(string symbol) // Assuming you want to fetch data by a stock symbol
        {
            // Fetch the data from your database (or however you populate the model)
            var companyOverview = await _context.CompanyOverview.FirstOrDefaultAsync(c => c.Symbol == symbol);

            // Pass it to the view
            return View(companyOverview);
        }

        [HttpPost]
        public async Task<IActionResult> SaveIt(CompanyOverviewed model)
        {
            // Here you'd save the provided model to your database
            // This is just a simplistic example. You'd likely want to do checks, handle updates vs. new entries, etc.
            _context.Add(model);
            await _context.SaveChangesAsync();

            return RedirectToAction("Overview");
        }
    


        [HttpGet("getsearch")]
        public IActionResult GetSearch()
        {
            return Ok("Index");
        }


        [HttpPost("createsearch")]
        public async Task<IActionResult> CreateSearch(string symbol)
        {
            var apiKey = "FLW875WO7JXEYS29";
            var baseUrl = "https://www.alphavantage.co/query";

            using var client = new HttpClient();
            var response = await client.GetStringAsync($"{baseUrl}?function=OVERVIEW&symbol={symbol}&apikey={apiKey}");
            var companyOverview = JsonSerializer.Deserialize<CompanyOverviewed>(response);
            var jsonContent = new StringContent(
                JsonSerializer.Serialize(companyOverview),
                Encoding.UTF8,
                "application/json");

            var results = await client.PostAsync("http://localhost:5237/savecompany", jsonContent);

           return RedirectToPage("CompanyOverview", results);

        }

    }
}