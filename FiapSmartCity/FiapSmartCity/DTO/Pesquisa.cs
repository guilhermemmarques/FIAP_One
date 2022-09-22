using CsvHelper.Configuration.Attributes;

namespace FiapSmartCity.DTO;
{
    public class Pesquisa
{
    [Name("type")]
    public string Segmento { get; set; }
    [Name("address")]

    public string Logradouro { get; set; }
    [Name("number")]

    public string? Numero { get; set; }
    [Name("complement")]

    public string? Complemento { get; set; }
    [Name("zip_code")]

    public string Cep { get; set; }
    [Name("district")]

    public string Bairro { get; set; }
    [Name("city")]

    public string Cidade { get; set; }
    [Name("state")]

    public string UF { get; set; }

    public Pesquisa(string segmento, string logradouro, string? numero, string? complemento, string cep, string bairro, string cidade, string uf)
    {
        Segmento = segmento;
        Logradouro = logradouro;
        Numero = numero;
        Complemento = complemento;
        Cep = cep;
        Bairro = bairro;
        Cidade = cidade;
        UF = uf;
    }
}
}