using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RamenGo.Communication.Requests;
using RamenGo.Communication.Responses;
using RamenGo.Services.Order;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace RamenGo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private OrderService _orderService { get; set; }
        private readonly string _xApiKey;
        private readonly IConfiguration _configuration;

        public OrderController(OrderService orderService, IConfiguration configuration)
        {
            _orderService = orderService;
            _configuration = configuration;
            _xApiKey = _configuration.GetSection("x-api-key").Value;
        }

        /// <response code="200">Retorna a mensagem de sucesso</response>
        /// <response code="403">Retorna caso o x-api-key venha vázio ou inválido</response>
        [ProducesResponseType(typeof(OrderResponse),StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorResponse),StatusCodes.Status403Forbidden)]
        [HttpPost]
        public async Task<IActionResult> CreateOrderAsync([Required][FromBody] OrderRequest request, [Required][FromHeader(Name = "x-api-key")] string apiKey)
        {
            if (apiKey == null)
                return StatusCode(403, new ErrorResponse { Error = "x-api-key header missing" });

            if (apiKey != _xApiKey)
                return StatusCode(403, new ErrorResponse { Error = "invalid x-api-key header" });

            await _orderService.CreateOrderAsync(request);
            return Ok();
        }
    }
}
