using Microsoft.EntityFrameworkCore;
using TestJob.Contexts;
using TestJob.Interfaces;
using TestJob.Services;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
var configuration = builder.Configuration;
var connectionString = configuration.GetConnectionString("DefaultConnection");

services.AddDbContext<UserStatisticsContext>(options => 
    options.UseNpgsql(connectionString));
services.AddTransient<IConfigManager, ConfigManager>();
services.AddTransient<IQueryAnalyzer, QueryAnalyzer>();
services.AddMemoryCache();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();