using Microsoft.AspNetCore.Mvc;
using TindogService.Interfaces;

namespace TindogService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PetController
    {
        private readonly ITutorService _tutorService;

        public PetController(ITutorService tutorService)
        {
            _tutorService = tutorService;
        }
    }
}
