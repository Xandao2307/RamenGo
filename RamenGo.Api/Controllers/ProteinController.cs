using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RamenGo.Communication.Responses;
using RamenGo.Services.Protein;
using RamenGo.Services.Protein.Exceptions;
using RamenGo.Services.Responses.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace RamenGo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProteinController : ControllerBase
    {

        private ProteinService _proteinService { get; set; }
        private readonly string _xApiKey;
        private readonly IConfiguration _configuration;
        public ProteinController(ProteinService proteinService, IConfiguration configuration)
        {
            _proteinService = proteinService;
            _configuration = configuration;
            _xApiKey = _configuration.GetSection("x-api-key").Value;
        }

        [ProducesResponseType(typeof(ProteinResponse), StatusCodes.Status200OK)]
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
                var proteins = await _proteinService.GetAllAsync();
                return Ok(proteins);
            }
            catch (ProteinException e)
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
