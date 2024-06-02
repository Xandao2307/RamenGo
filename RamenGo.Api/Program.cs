using Microsoft.EntityFrameworkCore;
using RamenGo.Api.Controllers;
using RamenGo.Infrastructure.DbContexts;
using RamenGo.Services.Order;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<RamenGoDbContext>(opt => opt.UseInMemoryDatabase("RamenGo"));
builder.Services.AddScoped<OrderService>();
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
