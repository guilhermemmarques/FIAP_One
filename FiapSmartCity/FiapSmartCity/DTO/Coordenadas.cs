using CsvHelper.Configuration.Attributes;

namespace FiapSmartCity.DTO
{
    public class Coordenadas
    {
        [Name("latitude")]
        public string Latitude { get; set; }
        [Name("longetitude")]
        public string Longitude { get; set; }

        public Coordenadas(string latitude, string longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}
