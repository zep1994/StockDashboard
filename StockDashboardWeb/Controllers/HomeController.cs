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
      

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Search()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Search(string symbol)
        {
            var apiKey = "FLW875WO7JXEYS29";
            var baseUrl = "https://www.alphavantage.co/query";

            using var client = new HttpClient();
            var response = await client.GetStringAsync($"{baseUrl}?function=OVERVIEW&symbol={symbol}&apikey={apiKey}");
            var companyOverview = JsonSerializer.Deserialize<CompanyOverviewDto>(response);

            // Pass the data to the view for display and provide an option to save.
            if (companyOverview != null)
            {
                Save(companyOverview);
            }
            
            return View("Error");
        }

        [HttpPost]
        public async Task<IActionResult> Save(CompanyOverviewDto companyOverview)
        {
            using var client = new HttpClient();

            var jsonContent = new StringContent(
                JsonSerializer.Serialize(companyOverview),
                Encoding.UTF8,
                "application/json");

            var response = await client.PostAsync("http://localhost:5211/api/companies", jsonContent);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            // Handle error (display an error page or message)
            return View("Error");
        }

    }
}