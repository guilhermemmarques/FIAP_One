using FiapSmartCity.DTO;
using System.Security.Cryptography.Xml;

namespace FiapSmartCity.Service
{
    public interface IPythonService
    {
        IEnumerable<DataObject> Resultado(Pesquisa pesquisa);
    }
}
