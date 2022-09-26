using FiapSmartCity.DAL;
using FiapSmartCity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace FiapSmartCity.Controllers
{

    [ApiController]
    [Route("busca-endereco")]
    public class BuscaEnderecoController : ControllerBase
    {
        private readonly BuscaEnderecoDAL buscaEnderecoDAL;

        public BuscaEnderecoController()
        {
            buscaEnderecoDAL = new BuscaEnderecoDAL();
        }

        [HttpGet("{DescEnderecos:string}")]
        public ActionResult <Endereco> Get([FromRoute] string DescEnderecos)
        {
            try
            {
                Endereco endereco = buscaEnderecoDAL.Consultar(DescEnderecos);
                return Ok(endereco);
            } catch (KeyNotFoundException e)
            {
                throw e;
            }
        }
    }
}
