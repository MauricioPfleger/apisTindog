using TindogService.Controllers.Request;
using TindogService.Controllers.Responses;
using TindogService.Objetos;

namespace TindogService.Interfaces
{
    public interface ITutorService
    {
        public List<Tutor> ConsultarTutor(string nome);
        public List<Pet> ConsultarTutorPets(int idTutor);
        public Endereco? ConsultarTutorEndereco(int idTutor);
        public List<Pet> ConsultarPets(int idPais, int idEstado, int idCidade);
        public EnderecoResponse CadastrarEndereco(EnderecoRequest enderecoRequest);
        public void ValidarTutorEndereco(EnderecoRequest enderecoRequest);
    }
}
