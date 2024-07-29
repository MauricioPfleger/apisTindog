using Microsoft.AspNetCore.Mvc;
using TindogService.Interfaces;

namespace TindogService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PetController
    {
        private readonly IPetService _petService;

        public PetController(IPetService petService)
        {
            _petService = petService;
        }
    }
}
