using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Data;
using System.Net;
using System.Reflection.PortableExecutable;
using TindogService;
using TindogService.Controllers.Responses;
using TindogService.Interfaces;
using TindogService.Objetos;

namespace TinDog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TutorController : ControllerBase
    {
        private readonly ITutorService _tutorService;

        public TutorController(ITutorService tutorService)
        {
            _tutorService = tutorService;
        }

        [HttpGet("v1/informacoes")]
        [ProducesResponseType(typeof(Tutor), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        public IActionResult ConsultarTutor([FromQuery] string nome)
        {
            try
            {
                var listaTutores = _tutorService.ConsultarTutor(nome);
                        
                if (listaTutores.Count > 0)
                    return Ok(listaTutores);
                else
                    return BadRequest(new ErrorResponse() { Mensagem = "Ocorreu um erro ao obter os tutores." });                
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse() { Mensagem = $"Ocorreu um erro ao obter os tutores: {ex.Message}"});
            }
        }
    }
}
