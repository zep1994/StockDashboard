using Microsoft.AspNetCore.Builder;
using System;
using Microsoft.AspNetCore.Identity;
using System.Text;
using StockDashboardAPI.Data;
using StockDashboardAPI.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Add services to the container.

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQLConnection")));


var app = builder.Build();

// Configure the HTTP request pipeline.

//app.UseHttpsRedirection();

builder.Services.AddHttpClient();
app.UseAuthorization();

app.MapControllers();

app.Run();
