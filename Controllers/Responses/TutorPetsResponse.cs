using TindogService.Objetos;

namespace TindogService.Controllers.Responses
{
    public class TutorPetsResponse
    {
        public List<Pet> Pets { get; set; }

        public TutorPetsResponse() { 
            Pets = new List<Pet>();
        }
    }
}
