using Microsoft.AspNetCore.Mvc;
using StockDashboardWeb.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace StockDashboardWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyOverviewController : ControllerBase
    {
        private const string ApiKey = "FLW875WO7JXEYS29";
        private const string BaseUrl = "https://www.alphavantage.co/query";

        [HttpGet("{symbol}")]
        public async Task<IActionResult> GetCompanyOverview(string symbol)
        {
            using HttpClient client = new HttpClient();
            var endpoint = $"{BaseUrl}?function=OVERVIEW&symbol={symbol}&apikey={ApiKey}";

            try
            {
                var response = await client.GetFromJsonAsync<CompanyOverview>(endpoint);
                if (response == null) return NotFound("Company overview not found.");

                return Ok(response);
            }
            catch (HttpRequestException e)
            {
                return BadRequest("Error fetching company overview: " + e.Message);
            }
        }
    }
}