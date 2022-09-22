using FiapSmartCity.DTO;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.Collections.Generic;

namespace FiapSmartCity.Service
{
    public class ScriptService
    {
        public List<T> Resultado(Pesquisa pesquisa)
        {
            var coordenadas = ConverterCsv(pesquisa);


        }

        private Coordenadas ConverterCsv(Pesquisa pesquisa)
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

            //TODO criar método para rodar o script do Python

            using (var reader = new StreamReader("../../../../../Properties/coordenadas.csv")) 

            using (var csv = new CsvReader(reader, config))
            {
                coordenadas = csv.GetRecords<Coordenadas>();

            }

            return coordenadas;
        }
    }
}
