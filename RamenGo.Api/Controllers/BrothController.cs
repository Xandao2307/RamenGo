using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RamenGo.Communication.Responses;
using RamenGo.Services.Broth;
using RamenGo.Services.Responses.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace RamenGo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrothController : ControllerBase
    {
        private BrothService _brothService{ get; set; }
        private readonly string _xApiKey;
        private readonly IConfiguration _configuration;
        public BrothController(BrothService brothService, IConfiguration configuration)
        {
            _brothService = brothService;
            _configuration = configuration;
            _xApiKey = _configuration.GetSection("x-api-key").Value;
        }

        [ProducesResponseType(typeof(BrothResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync([Required][FromHeader(Name = "x-api-key")] string apiKey) 
        {
            if (apiKey == null)
                return StatusCode(403, new ErrorResponse { Error = "x-api-key header missing" });

            if (apiKey != _xApiKey)
                return StatusCode(403, new ErrorResponse { Error = "invalid x-api-key header" });

            try
            {
                var broths = await _brothService.GetAllAsync();
                return Ok(broths);
            }
            catch(BrothException e)
            {
                return StatusCode(403, new ErrorResponse { Error = e.Message });

            }
            catch (Exception e)
            {

               return StatusCode(500, new ErrorResponse { Error = e.Message });
            }
                    }
    }
}
