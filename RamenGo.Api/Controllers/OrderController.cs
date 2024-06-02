using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RamenGo.Communication.Requests;
using RamenGo.Communication.Responses;
using RamenGo.Services.Order;
using RamenGo.Services.Order.Exceptions;
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

        [ProducesResponseType(typeof(OrderResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<IActionResult> CreateOrderAsync([Required][FromBody] OrderRequest request, [Required][FromHeader(Name = "x-api-key")] string apiKey)
        {
            if (apiKey == null)
                return StatusCode(403, new ErrorResponse { Error = "x-api-key header missing" });

            if (apiKey != _xApiKey)
                return StatusCode(403, new ErrorResponse { Error = "invalid x-api-key header" });

            try
            {
               var responseOrder =  await _orderService.CreateOrderAsync(request);
                return Created("",responseOrder);
            }
            catch (InvalidBrothAndProteinException e)
            {
                return BadRequest(new ErrorResponse { Error = e.Message });
            }
            catch(Exception e) 
            {
                return StatusCode(500, new ErrorResponse { Error = e.Message });
            }

        }
    }
}
