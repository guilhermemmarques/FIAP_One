using FiapSmartCity.DTO;
using System.Net.Http.Headers;
using System.Security.Cryptography.Xml;

namespace FiapSmartCity.Service
{
    public class ApiService
    {
        private readonly string url = "https://maps.googleapis.com/maps/api/place/nearbysearch/json";

        public IEnumerable<DataObject> ChamarApiGoogle(IEnumerable<Coordenadas> coordenadas, string segmento)
        {
            var coordenada = coordenadas.First();
            string urlParametros = $"?location={coordenada.Latitude}2C{coordenada.Latitude}&type={segmento}&api_key=AIzaSyCwaZgsNyb36X4_m0103cb3pzRaTISB2Lw";

            HttpClient client = new()
            {
                BaseAddress = new Uri(url)
            };
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(urlParametros).Result;
            if (response.IsSuccessStatusCode)
            { return response.Content.ReadAsAsync<IEnumerable<DataObject>>().Result; }
            else { return Enumerable.Empty<DataObject>(); }
        }


    }
}
