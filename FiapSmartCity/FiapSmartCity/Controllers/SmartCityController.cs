using FiapSmartCity.DTO;
using FiapSmartCity.Service;
using Microsoft.AspNetCore.Mvc;

namespace FiapSmartCity.Controllers
{
    [ApiController]
    [Route("busca-bairro")]
    public class SmartCityController : ControllerBase
    {
        private readonly IPythonService _scriptService;

        public SmartCityController(IPythonService scriptService)
        {
            _scriptService = scriptService;
        }

        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult Post([FromBody] Pesquisa pesquisa)
        {
            return Ok(_scriptService.Resultado(pesquisa));
        }
    }
}