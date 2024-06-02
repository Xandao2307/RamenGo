using Microsoft.EntityFrameworkCore;
using RamenGo.Api.Controllers;
using RamenGo.Infrastructure.DbContexts;
using RamenGo.Services;
using RamenGo.Services.Broth;
using RamenGo.Services.Order;
using RamenGo.Services.Protein;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<RamenGoDbContext>(opt => opt.UseInMemoryDatabase("RamenGo"));
builder.Services.AddScoped<OrderService>();
builder.Services.AddScoped<BrothService>();
builder.Services.AddScoped<ProteinService>();
builder.Services.AddScoped<DbInitialiazer>();
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
