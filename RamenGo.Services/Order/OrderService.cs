using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.Extensions.Configuration;
using RamenGo.Communication.Requests;
using RamenGo.Communication.Responses;
using RamenGo.Infrastructure.DbContexts;
using RamenGo.Services.Order.Exceptions;
using RamenGo.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace RamenGo.Services.Order
{
    public class OrderService
    {
        private RamenGoDbContext _dbContext { get; set; }
        private readonly IConfiguration _configuration;
        private DbInitialiazer _initialiazer { get; set; }
        public OrderService(RamenGoDbContext dbContext, IConfiguration configuration, DbInitialiazer initialiazer)
        {
            _dbContext = dbContext;
            _configuration = configuration;
            _initialiazer = initialiazer;
            _initialiazer.InitiateAsync().Wait();
        }

        public async Task<OrderResponse> CreateOrderAsync(OrderRequest request)
        {
            if (_dbContext == null)
                throw new OrderException("could not place order");

            var meal = _dbContext.Meals.FirstOrDefault(m => m.ProteinId == request.ProteinId && m.BrothId == request.BrothId)
                ?? throw new InvalidBrothAndProteinException("both brothId or proteinId is invalid");
            var orderId = await GetOrderIdAsync();

            var order = new Infrastructure.Entities.Order() { Id = int.Parse(orderId), Meal = meal, MealId = meal.Id };
            _dbContext.Orders.Add(order);
            await _dbContext.SaveChangesAsync();
            return new OrderResponse() { Id = int.Parse(orderId), Description = meal.Description, Image = meal.Image };

        }

        private async Task<string> GetOrderIdAsync()
        {
            var apiKey = _configuration.GetSection("x-api-key").Value;
            var urlOrderService = _configuration.GetSection("urlOrderService").Value;

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("x-api-key", apiKey);
                HttpResponseMessage response = await client.PostAsync(urlOrderService, null);
                var json = JsonSerializer.Deserialize<ResponseHttp>(await response.Content.ReadAsStringAsync());
                return json.orderId;
            }
        }
    }

    public class ResponseHttp
    {
        public string orderId { get; set; }
    }

}


