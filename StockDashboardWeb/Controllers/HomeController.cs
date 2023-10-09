using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using StockDashboardAPI.Models;
using StockDashboardWeb.Dto;
using StockDashboardWeb.Models;
using System.Diagnostics;
using System.Text;
using System.Text.Json;

namespace StockDashboardWeb.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet("/")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("search")]
        public IActionResult Search()
        {
            return View("Search");
        }



        [HttpPost("search")]
        public async Task<IActionResult> Search(string symbol)
        {
            var apiKey = "FLW875WO7JXEYS29";
            var baseUrl = "https://www.alphavantage.co/query";

            using var client = new HttpClient();
            var response = await client.GetStringAsync($"{baseUrl}?function=OVERVIEW&symbol={symbol}&apikey={apiKey}");
            var companyOverview = JsonSerializer.Deserialize<StockDashboardAPI.Models.CompanyOverview>(response);
            var jsonContent = new StringContent(
                JsonSerializer.Serialize(companyOverview),
                Encoding.UTF8,
                "application/json");

            var results = await client.PostAsync("http://localhost:5237/savecompany", jsonContent);
            if (results.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Home");
            }

            return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}