using Microsoft.AspNetCore.Mvc;
using StockDashboardWeb.Models;
using System.Text.Json;

namespace StockDashboardWeb.Controllers
{
    public class WinnersLosersController : ControllerBase
    {
        private const string ApiKey = "FLW875WO7JXEYS29";
        private const string BaseUrl = $"https://www.alphavantage.co/query?function=TOP_GAINERS_LOSERS&apikey={ApiKey}";


        [HttpGet("GetTopGainersLosers")]
        public async Task<IActionResult> IWinSearch()
        {
            using var client = new HttpClient();

            if(client == null) {return NotFound();}

            var response = await client.GetStringAsync(BaseUrl);
            var data = JsonSerializer.Deserialize<WinLose>(response);
            return Ok(data);
        }

    }
}