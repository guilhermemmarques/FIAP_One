using FiapSmartCity.DTO;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.Diagnostics;
using System.Security.Cryptography.Xml;


namespace FiapSmartCity.Service
{
    public class ScriptService
    {
        private readonly ApiService _apiService;
        public ScriptService(ApiService apiService)
        {
            _apiService = apiService;
        }

        public IEnumerable<DataObject> Resultado(Pesquisa pesquisa)
        {
            var coordenadas = ConverterCsv(pesquisa);
            return _apiService.ChamarApiGoogle(coordenadas, pesquisa.Segmento);

        }

        private static IEnumerable<Coordenadas> ConverterCsv(Pesquisa pesquisa)
        {
            IEnumerable<Coordenadas> coordenadas;
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true
            };
            using (var writer = new StreamWriter("../../../../../Properties/converter.csv"))
            using (var csv = new CsvWriter(writer, config))
            {
                csv.WriteHeader<Pesquisa>();
                csv.NextRecord();
                csv.WriteRecord(pesquisa);

            }

            RodarScript();

            using (var reader = new StreamReader("../../../../../Properties/coordenadas.csv"))

            using (var csv = new CsvReader(reader, config))
            {
                coordenadas = csv.GetRecords<Coordenadas>();

            }

            return coordenadas;
        }

        private static void RodarScript()
        {
            Process cmd = new();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();

            string comando;
            comando = "/C python localizacao.py";
            Process.Start("CMD.exe", comando);
        }


    }

}