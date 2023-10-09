using Microsoft.AspNetCore.Mvc;
using StockDashboardWeb.Models;
using System.Text.Json;

namespace StockDashboardWeb.Controllers
{
    public class WinnersLosersController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public WinnersLosersController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        // Sample data for demonstration purposes
        private static readonly List<WinLose> SampleData = new List<WinLose>
        {
            new WinLose { Id = 1, Ticker = "AAPL", Price = "150.50", Change_amount = 2, Change_percentage = "+1.5%", Volume = "10M" },
            new WinLose { Id = 2, Ticker = "GOOGL", Price = "2800.70", Change_amount = -30, Change_percentage = "-1.1%", Volume = "8M" },
            // ... add more sample data
        };

        [HttpGet("CheckWinLoss")]
        public IActionResult Index()
        {
            return StatusCode(200);
        }

        [HttpPost("GetTopGainersLosers")]
        public async Task<IActionResult> GetTopGainersLosers()
        {
            var apiKey = "FLW875WO7JXEYS29";
            var baseURL = "https://www.alphavantage.co/query";
            var endpoint = $"{baseURL}?function=TOP_GAINERS_LOSERS&apikey={apiKey}";

            if (string.IsNullOrEmpty(endpoint))
                return BadRequest("API key is required.");

            var response = await _httpClient.GetAsync(endpoint);
            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            var responseData = await JsonSerializer.DeserializeAsync<WinLose[]>(responseStream);
            return Ok(responseData);
        }
    }
}