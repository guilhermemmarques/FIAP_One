using FiapSmartCity.DAL;
using FiapSmartCity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace FiapSmartCity.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class BuscaEnderecoController : ControllerBase
    {
        private readonly BuscaEnderecoDAL buscaEnderecoDAL;

        public BuscaEnderecoController()
        {
            buscaEnderecoDAL = new BuscaEnderecoDAL();
        }

        [HttpGet("{IdEndereco:int}")]
        public ActionResult <Endereco> Get([FromRoute] int IdEndereco)
        {
            try
            {
                Endereco endereco = buscaEnderecoDAL.Consultar(IdEndereco);
                return Ok(endereco);
            } catch (KeyNotFoundException e)
            {
                throw e;
            }
        }
    }
}
