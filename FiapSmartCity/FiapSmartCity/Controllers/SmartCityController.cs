using FiapSmartCity.DTO;
using FiapSmartCity.Service;
using Microsoft.AspNetCore.Mvc;

namespace FiapSmartCity.Controllers
{
    [ApiController]
    [Route("busca-bairro")]
    public class SmartCityController : ControllerBase
    {
        private readonly ScriptService _scriptService;

        public SmartCityController(ScriptService scriptService)
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