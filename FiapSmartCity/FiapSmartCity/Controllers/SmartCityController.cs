using FiapSmartCity.Models;
using Microsoft.AspNetCore.Mvc;

namespace FiapSmartCity.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SmartCityController : ControllerBase
    {
        [HttpGet]
        [Route("/termos-uso")]
        public ActionResult<TermosUso> Get()
        {
            TermosUso termos = new TermosUso();
            return Ok(termos.RetornaTermo());
        }
    }
}