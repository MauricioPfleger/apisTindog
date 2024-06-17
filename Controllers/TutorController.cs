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
                return BadRequest(new ErrorResponse() { Mensagem = $"Ocorreu um erro ao obter os tutores: {ex.Message}" });
            }
        }

        [HttpGet("v1/{idTutor}/pets")]
        [ProducesResponseType(typeof(TutorPetsResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        public IActionResult ConsultarTutor([FromRoute] int idTutor)
        {
            try
            {
                var listaPets = _tutorService.ConsultarTutorPets(idTutor);

                if (listaPets.Count > 0)
                    return Ok(listaPets);
                else
                    return BadRequest(new ErrorResponse() { Mensagem = "Ocorreu um erro ao obter os pets do tutor." });
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse() { Mensagem = $"Ocorreu um erro ao obter os pets do tutor: {ex.Message}" });
            }
        }

        [HttpGet("v1/{idTutor}/endereco")]
        [ProducesResponseType(typeof(Endereco), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        public IActionResult ConsultarTutorEndereco([FromRoute] int idTutor)
        {
            try
            {
                Endereco endereco = new Endereco();
                // var listaPets = _tutorService.ConsultarTutorPets(idTutor); chamar o método novo da interface

                if (endereco.Id > 0)
                    return Ok(endereco);
                else
                    return BadRequest(new ErrorResponse() { Mensagem = "" }); // Acrescentar uma mensagem de erro que faça sentido
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse() { Mensagem = $": {ex.Message}" }); // Acrescentar uma mensagem de erro que faça sentido
            }
        }
    }
}
