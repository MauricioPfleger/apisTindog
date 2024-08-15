using TindogService.Controllers.Request;
using TindogService.Objetos;

namespace TindogService.Interfaces
{
    public interface IPetService
    {
        public bool inserirPet(int idTutor, PetRequest pet);
        public bool AtualizarPet(int idPet, PetRequest pet);
        public bool ExcluirPet(int idPet);

    }
}
