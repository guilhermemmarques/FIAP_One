using FiapSmartCity.DTO;
using System.Security.Cryptography.Xml;

namespace FiapSmartCity.Service
{
    public interface IGoogleService
    {
        IEnumerable<Result> ChamarApiGoogleAsync(IEnumerable<Coordenadas> coordenadas, string segmento);
    }
}
