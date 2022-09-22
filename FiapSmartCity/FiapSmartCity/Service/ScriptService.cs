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
            converterCsv();


        }

        private T converterCsv()
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true
            }

            using (var reader = new StreamReader())
        }
    }
}
