using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StockDashboardAPI.Data;
using StockDashboardAPI.Models;
using StockDashboardWeb.Dto;
using StockDashboardWeb.Models;
using System.Diagnostics;
using System.Text;
using System.Text.Json;
using CompanyOverview = StockDashboardAPI.Models.CompanyOverview;

namespace StockDashboardWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;  // Assume you have a DbContext for your database

        public async Task<IActionResult> Oview(string symbol) // Assuming you want to fetch data by a stock symbol
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

        [HttpGet("/")]
        public IActionResult Index()
        {
            return View("List");
        }

        [HttpGet("model")]
        public IActionResult Models()
        {
            return Ok(200);
        }

        public ActionResult UsingDynamic()
        {
            return View(new
            {
                TestString = "This is a test string"
            });

        }
    }
 
}