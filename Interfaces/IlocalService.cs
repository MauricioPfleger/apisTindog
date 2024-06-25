using TindogService.Controllers.Responses;

namespace TindogService.Interfaces
{
    public interface ILocalService
    {
        public List<EstadoResponse> ConsultaEstados();
        public List<CidadeResponse> ConsultaCidades();


    }
}
