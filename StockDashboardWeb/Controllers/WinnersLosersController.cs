using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StockDashboardWeb.Models;
using System.Text;
using System.Text.Json;

namespace StockDashboardWeb.Controllers
{
    public class WinnersLosersController : Controller
    {
        private const string ApiKey = "FLW875WO7JXEYS29";
        private const string BaseUrl = "https://www.alphavantage.co/query?function=TOP_GAINERS_LOSERS&apikey=" + ApiKey;


        [HttpGet("Home/GetTopGainersLosers")]
        public async Task<IActionResult> Index()
        {
            using var client = new HttpClient();
            var response = await client.GetStringAsync(BaseUrl);
            var data = JsonSerializer.Deserialize<WinLose>(response);

            return View("Index");
        }

    }
}