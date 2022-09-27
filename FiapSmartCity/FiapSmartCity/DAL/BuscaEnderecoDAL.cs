using FiapSmartCity.Models;

namespace FiapSmartCity.DAL
{
    public class BuscaEnderecoDAL
    {

        //Lista para armazenar enderecos cadastrados no banco
        private static Dictionary<long, Endereco> bdBuscaEnderecos = new Dictionary<long, Endereco>();
        private static int contadorBanco = 1;

        //Simulando banco de dados
        static BuscaEnderecoDAL()
        {
            Endereco PresidenteJoseLinhares = new Endereco();
            PresidenteJoseLinhares.IdEndereco = 345;
            PresidenteJoseLinhares.DescEnderecos = "Presidente José Linhares, 555";
            PresidenteJoseLinhares.CEP = 09345654;
            PresidenteJoseLinhares.UF = "RJ";

            bdBuscaEnderecos.Add(1, PresidenteJoseLinhares);

        }
        
        public void Inserir(Endereco Endereco)
        {
            contadorBanco++;
            Endereco.IdEndereco = contadorBanco;
            bdBuscaEnderecos.Add(contadorBanco, Endereco);
        }

        public Endereco Consultar( int IdEndereco)
        {
            return bdBuscaEnderecos[IdEndereco];
        }

        public IList<Endereco> Listar()
        {
            return new List<Endereco>(bdBuscaEnderecos.Values);
        }

        public void Excluir(int IdEndereco)
        {
            bdBuscaEnderecos.Remove(IdEndereco);
        }

    }
}
