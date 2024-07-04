using TindogService.Controllers.Responses;
using TindogService.Objetos;

namespace TindogService.Interfaces
{
    public interface ILocalService
    {
        public List<Pais> ConsultaPaises();
        public List<EstadoResponse> ConsultaEstados(int idPais);
        public List<CidadeResponse> ConsultaCidades();


    }
}
