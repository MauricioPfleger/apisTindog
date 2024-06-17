using TindogService.Objetos;

namespace TindogService.Interfaces
{
    public interface ITutorService
    {
        public List<Tutor> ConsultarTutor(string nome);
        public List<Pet> ConsultarTutorPets(int idTutor);
        // Adicionar a interface do método que realiza a busca
    }
}
