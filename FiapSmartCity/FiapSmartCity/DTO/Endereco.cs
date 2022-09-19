namespace FiapSmartCity.DTO
{
    public class Endereco
    {
        public string Logradouro { get; set; }
        public string? Numero { get; set; }
        public string? Complemento { get; set; }
        public string Cep { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }

        public Endereco(string logradouro, string? numero, string? complemento, string cep, string bairro, string cidade, string uF)
        {
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Cep = cep;
            Bairro = bairro;
            Cidade = cidade;
            UF = uF;
        }
    }
}