using Microsoft.AspNetCore.Mvc;
using StockDashboardWeb.Models;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace StockDashboardWeb.Controllers
{
    public class CompanyOverviewController : Controller
    {
        private readonly HttpClient _httpClient;
        private const string ALPHA_VANTAGE_API_KEY = "FLW875WO7JXEYS29";
        private const string ALPHA_VANTAGE_BASE_URL = "https://www.alphavantage.co/query";
        private const string BACKEND_API_URL = "http://yourbackendapi.com/api/companyoverviews"; // replace with your endpoint

        public CompanyOverviewController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        [HttpPost("Home/search")]
        public async Task<IActionResult> Search(string symbol)
        {
            using var client = new HttpClient();
            var response = await client.GetStringAsync($"{ALPHA_VANTAGE_BASE_URL}?function=OVERVIEW&symbol={symbol}&apikey={ALPHA_VANTAGE_API_KEY}");
            var companyOverview = JsonSerializer.Deserialize<CompanyOverviewed>(response);

            // Pass the data to the view for display and provide an option to save.
            return View("Home/Display", companyOverview);
        }

        //[HttpPost]
        //public async Task<IActionResult> Save(CompanyOverviewed companyOverview)
        //{
        //    using var client = new HttpClient();
        //    var jsonContent = new StringContent(JsonSerializer.Serialize(companyOverview), Encoding.UTF8, "application/json");
        //    var response = await client.PostAsync(BACKEND_API_URL, jsonContent);

        //    if (response.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction("Index");
        //    }

        //    // Handle error (display an error page or message)
        //    return View("Error");
        //}

        [HttpGet("lost")]
        public async Task<IActionResult> List()
        {
            using var client = new HttpClient();
            var response = await client.GetStringAsync(BACKEND_API_URL);
            var companyOverviews = JsonSerializer.Deserialize<List<CompanyOverviewed>>(response);

            return View(companyOverviews);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            using var client = new HttpClient();
            await client.DeleteAsync($"{BACKEND_API_URL}/{id}");
            return RedirectToAction("List");
        }

        //[HttpGet("SaveToDb")]
        //public async Task<IActionResult> SaveToDb(string symbol)
        //{
        //    var apikey = "FLW875WO7JXEYS29";
        //    var baseURL = "https://www.alphavantage.co/query";
        //    var apiUrl = $"{baseURL}?function=OVERVIEW&symbol={symbol}&apikey={apikey}";
        //    var response = await _httpClient.GetAsync(apiUrl);
        //    response.EnsureSuccessStatusCode();

        //    using var responseStream = await response.Content.ReadAsStreamAsync();
        //    var coData = await JsonSerializer.DeserializeAsync<CompanyOverviewed>(responseStream);

        //    if (coData != null)
        //    {
        //        await _context.CompanyOverview.AddAsync(coData);
        //        await _context.SaveChangesAsync();
        //    }

        //    // Redirect to another action or return some view as necessary
        //    return View("CompanyOverview", coData);
        //}        //[HttpGet("SaveToDb")]
        //public async Task<IActionResult> SaveToDb(string symbol)
        //{
        //    var apikey = "FLW875WO7JXEYS29";
        //    var baseURL = "https://www.alphavantage.co/query";
        //    var apiUrl = $"{baseURL}?function=OVERVIEW&symbol={symbol}&apikey={apikey}";
        //    var response = await _httpClient.GetAsync(apiUrl);
        //    response.EnsureSuccessStatusCode();

        //    using var responseStream = await response.Content.ReadAsStreamAsync();
        //    var coData = await JsonSerializer.DeserializeAsync<CompanyOverviewed>(responseStream);

        //    if (coData != null)
        //    {
        //        await _context.CompanyOverview.AddAsync(coData);
        //        await _context.SaveChangesAsync();
        //    }

        //    // Redirect to another action or return some view as necessary
        //    return View("CompanyOverview", coData);
        //}

        //[HttpPost("SaveToDb")]
        //public async Task<IActionResult> SaveToDb(string symbol)
        //{
        //    var apiKey = "FLW875WO7JXEYS29";
        //    var baseURL = "https://www.alphavantage.co/query";
        //    var apiUrl = $"{baseURL}?function=OVERVIEW&function=OVERVIEW&apikey={apiKey}";
        //    var response = await _httpClient.GetAsync(apiUrl);
        //    response.EnsureSuccessStatusCode();

        //    using var responseStream = await response.Content.ReadAsStreamAsync();
        //    var coData = await JsonSerializer.DeserializeAsync<CompanyOverview>(responseStream);

        //    if (coData != null)
        //    {
        //        await _context.CompanyOverviews.AddAsync(coData);
        //        await _context.SaveChangesAsync();
        //    }

        //    // Redirect to another action or return some view as necessary
        //    return View("CompanyOverview", coData);
        //}

    }


    //[HttpGet("GetGainsLosers")]
    //public async Task<IActionResult> GetGainsLosers()
    //{
    //    var apikey = "flw875wo7jxeys29";
    //    var top_gainers_losers = "top_gainers_losers"; // example, replace with your desired symbol or make it dynamic
    //    var baseurl = "https://www.alphavantage.co/query";
    //    var endpoint = $"{baseurl}?function=overview&function={top_gainers_losers}&apikey={apikey}";


    //    var response = await _httpClient.GetAsync(baseurl + apikey);
    //    response.EnsureSuccessStatusCode();

    //    using var responsestream = await response.Content.ReadAsStreamAsync();
    //    var responsedata = await JsonSerializer.DeserializeAsync<WinLose[]>(responsestream);
    //    return Ok(responsedata);
    //}

    //[HttpPost]
    //[Route("api/winlose")]
    //public async Task<IActionResult> getAll()
    //{
    //    var apiKey = "FLW875WO7JXEYS29";
    //    var TOP_GAINERS_LOSERS = "TOP_GAINERS_LOSERS"; // Example, replace with your desired symbol or make it dynamic
    //    var baseURL = "https://www.alphavantage.co/query";
    //    var endpoint = $"{baseURL}?function=OVERVIEW&function={TOP_GAINERS_LOSERS}&apikey={apiKey}";

    //    var response = await _httpClient.GetAsync(endpoint);
    //    response.EnsureSuccessStatusCode();

    //    using var responseStream = await response.Content.ReadAsStreamAsync();
    //    var coData = await JsonSerializer.DeserializeAsync<CompanyOverview>(responseStream);

    //    if (coData != null)
    //    {
    //        await _context.CompanyOverviews.AnyAsync(coData);
    //        await _context.SaveChangesAsync();
    //    }

    //    // Redirect to another action or return some view as necessary
    //    return RedirectToAction("Index");
    //    //var overview = JsonSerializer.Deserialize<CompanyOverviewDto>(response);
    //    //return Ok(overview);
    //}



    //[HttpGet]
    //[Route("api/winners")]
    //public async Task<List<WinLose>> Show()
    //{
    //    var apiKey = "FLW875WO7JXEYS29";
    //    var url = $"https://www.alphavantage.co/query?function=TOP_GAINERS_LOSERS&apikey={apiKey}";

    //    try
    //    {
    //        var response = await _httpClient.GetFromJsonAsync<WinLose>(url);
    //        return response?.WinLosers ?? new List<WinLose>();
    //    }
    //    catch (Exception ex)
    //    {
    //        // Handle exceptions, log errors, etc.
    //        throw;
    //    }
    //}







    //[ApiController]
    //[Route("[controller]")]
    //public class CompanyOverviewController : ControllerBase
    //{
    //    private const string ApiKey = "FLW875WO7JXEYS29";
    //    private const string BaseUrl = "https://www.alphavantage.co/query";

    //    [HttpGet("{symbol}")]
    //    public async Task<IActionResult> GetCompanyOverview(string symbol)
    //    {
    //        using HttpClient client = new HttpClient();
    //        var endpoint = $"{BaseUrl}?function=OVERVIEW&symbol={symbol}&apikey={ApiKey}";

    //        try
    //        {
    //            var response = await client.GetFromJsonAsync<CompanyOverview>(endpoint);
    //            if (response == null) return NotFound("Company overview not found.");

    //            return Ok(response);
    //        }
    //        catch (HttpRequestException e)
    //        {
    //            return BadRequest("Error fetching company overview: " + e.Message);
    //        }
    //    }
    //}
}