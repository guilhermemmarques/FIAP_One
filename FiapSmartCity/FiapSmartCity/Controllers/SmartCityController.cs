using FiapSmartCity.DTO;
using FiapSmartCity.Service;
using FiapSmartCity.Models;
using Microsoft.AspNetCore.Mvc;

namespace FiapSmartCity.Controllers
{
    [ApiController]
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
        [Route("busca-bairro")]

        public IActionResult Post([FromBody] Pesquisa pesquisa)
        {
            return Ok(_scriptService.Resultado(pesquisa));
        }
        [HttpGet]
        [Route("/termos-uso")]
        public ActionResult<TermosUso> Get()
        {
            TermosUso termos = new TermosUso();
            return Ok(termos.RetornaTermo());
        }
    }
}