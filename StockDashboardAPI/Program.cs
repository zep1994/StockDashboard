using StockDashboardAPI.Data;
using Microsoft.EntityFrameworkCore;
using ServiceStack;
using Autofac.Core;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Add services to the container
builder.Services.AddHttpClient();


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQLConnection")));

builder.Services.AddDbContext<AppDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.

//app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();
