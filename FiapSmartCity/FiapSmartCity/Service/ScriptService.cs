using FiapSmartCity.DTO;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.Diagnostics;
using System.Collections.Generic;
using System.Net;
using System.Net.Http.Headers;


namespace FiapSmartCity.Service
{
    public class ScriptService
    {
        public List<T> Resultado(Pesquisa pesquisa)
        {
            var coordenadas = ConverterCsv(pesquisa);
            return ChamarApiGoogle(coordenadas, pesquisa.Segmento);

        }

        private static Coordenadas ConverterCsv(Pesquisa pesquisa)
        {
            var coordenadas;
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

        private List<T> ChamarApiGoogle(Coordenadas coordenadas, string segmento)
        { }
        private string url = "https://maps.googleapis.com/maps/api/place/nearbysearch/json";
        private string urlParametros = $"?location={coordenadas.Latitude}2C{coordenadas.Longitude}&type={segmento}&api_key=AIzaSyCwaZgsNyb36X4_m0103cb3pzRaTISB2Lw";
        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri(url);
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(urlParametros).Result;
            if (response.IsSuccessStatusCode)
            {return response.Content.ReadAsAsync<IEnumerable<DataObject>>().Result;}
        }

    }   
}


