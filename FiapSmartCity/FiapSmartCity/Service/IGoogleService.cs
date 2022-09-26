using FiapSmartCity.DTO;
using System.Security.Cryptography.Xml;

namespace FiapSmartCity.Service
{
    public interface IGoogleService
    {
        IEnumerable<DataObject> ChamarApiGoogle(IEnumerable<Coordenadas> coordenadas, string segmento);
    }
}
