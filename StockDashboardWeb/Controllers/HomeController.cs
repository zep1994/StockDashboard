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
            return View("List");
        }

        [HttpGet("model")] public IActionResult Models()
        {
            return Ok(200);
        }

    }
}