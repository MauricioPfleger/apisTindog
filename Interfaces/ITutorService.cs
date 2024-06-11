using TindogService.Objetos;

namespace TindogService.Interfaces
{
    public interface ITutorService
    {
        public List<Tutor> ConsultarTutor(string nome);
    }
}
