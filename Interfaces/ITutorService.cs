using TindogService.Objetos;

namespace TindogService.Interfaces
{
    public interface ITutorService
    {
        public List<Tutor> ConsultarTutor(string nome);
        public List<Pet> ConsultarTutorPets(int idTutor);
        public Endereco? ConsultarTutorEndereco(int idTutor);
        public List<Pet> ConsultarPets(int idPais, int idEstado, int idCidade);
        // Adicionar a interface do método que realiza a busca
    }
}
