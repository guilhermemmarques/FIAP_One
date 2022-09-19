using FiapSmartCity.DTO;
using Microsoft.AspNetCore.Mvc;

namespace FiapSmartCity.Controllers
{
    [ApiController]
    [Route("busca-bairro")]
    public class SmartCityController : ControllerBase
    {

        private readonly ILogger<SmartCityController> _logger;

        public SmartCityController(ILogger<SmartCityController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult Post([FromBody] Endereco endereco) {

    }
}