using FiapSmartCity.DTO;
using System.Net.Http.Headers;
using System.Security.Cryptography.Xml;
using System.Text.Json;

namespace FiapSmartCity.Service
{
    public class ApiService : IGoogleService
    {
        private readonly string url = "https://maps.googleapis.com/maps/api/place/nearbysearch/json";

        public IEnumerable<Result> ChamarApiGoogleAsync(IEnumerable<Coordenadas> coordenadas, string segmento)
        {
            var coordenada = coordenadas.First();
            string urlParametros = $"?location={coordenada.Latitude}2C{coordenada.Longitude}&type={segmento}&api_key=AIzaSyCwaZgsNyb36X4_m0103cb3pzRaTISB2Lw";

            HttpClient client = new()
            {
                BaseAddress = new Uri(url)
            };
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(urlParametros).Result;
            if (response.IsSuccessStatusCode)
            { return response.Content.ReadAsAsync<IEnumerable<Result>>().Result; }
            else { return Enumerable.Empty<Result>(); }
        }


    }
}
