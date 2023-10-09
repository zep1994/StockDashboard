using Microsoft.AspNetCore.Mvc;
using StockDashboardAPI.Data;
using StockDashboardAPI.Models;
using System.Text.Json;

namespace StockDashboardAPI.Controllers
{
    public class CompanyOverviewsController : ControllerBase
    {

        private readonly AppDbContext _context;
        public CompanyOverviewsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("api/companny")]
        public async Task<IActionResult> SaveCompany([FromBody] CompanyOverview company)
        {
            _context.CompanyOverview.Add(company);
            await _context.SaveChangesAsync();
            Console.WriteLine("Sucess");
            return CreatedAtAction(nameof(SaveCompany), new { id = company.Id }, company);
        }

    }
}

//[HttpGet("{symbol}")]
//public async Task<IActionResult> GetCompanyOverview(string symbol)
//{
//    var apikey = "flw875wo7jxeys29";
//    var top_gainers_losers = "top_gainers_losers"; // example, replace with your desired symbol or make it dynamic
//    var baseurl = "https://www.alphavantage.co/query";
//    var endpoint = $"{baseurl}?function=overview&function={top_gainers_losers}&apikey={apikey}";

//    using HttpClient client = new HttpClient();
//    try
//    {
//        var response = await client.GetFromJsonAsync<CompanyOverview>(endpoint);
//        if (response == null) return NotFound("Company overview not found.");

//        return Ok(response);
//    }
//    catch (HttpRequestException e)
//    {
//        return BadRequest("Error fetching company overview: " + e.Message);
//    }
//}


//using Microsoft.AspNetCore.Mvc;
//using StockDashboardAPI.Data;
//using StockDashboardAPI.Models;
//using System.Threading.Tasks;
//using System.Net.Http;
//using System.Text.Json;
//using System.Threading.Tasks;
//using StockDashboardAPI.Dto;

//namespace StockDashboardAPI.Controllers
//{
//    [ApiController]
//    public class CompanyOverviewsController : ControllerBase
//    {
//        private readonly AppDbContext _context;

//        public CompanyOverviewsController(AppDbContext context)
//        {
//            _context = context;
//        }

//        //public async task<iactionresult> index()
//        //{
//        //    var apikey = "flw875wo7jxeys29";
//        //    var symbol = "aapl"; // example, replace with your desired symbol or make it dynamic
//        //var endpoint = $"https://www.alphavantage.co/query?function=overview&symbol={symbol}&apikey={apikey}";

//        //    var client = _clientfactory.createclient();
//        //    var response = await client.getstringasync(endpoint);

//        //    var overview = jsonserializer.deserialize<companyoverviewdto>(response);
//        //    return ok(overview);
//        //}

//        // POST: api/CompanyOverviews

//        [HttpPost]
//        [Route("api/companyoverview")]
//        public async Task<ActionResult<CompanyOverview>> PostCompanyOverview(CompanyOverview companyOverview)
//        {
//            _context.CompanyOverview.Add(companyOverview);
//            await _context.SaveChangesAsync();

//            return CreatedAtAction("GetCompanyOverview", new { id = companyOverview.Id }, companyOverview);
//        }

//    }
//}
