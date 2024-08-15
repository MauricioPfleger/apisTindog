using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.Common;
using System.Net;
using System.Reflection.PortableExecutable;
using TindogService;
using TindogService.Controllers.Request;
using TindogService.Controllers.Responses;
using TindogService.Interfaces;
using TindogService.Objetos;
using TindogService.Querys;
using TindogService.Services;

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

        [HttpGet("v1/{idTutor}")]
        [ProducesResponseType(typeof(Tutor), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        public IActionResult ConsultarTutor([FromRoute] int idTutor)
        {
            try
            {
                var listaTutores = _tutorService.ConsultarTutor(idTutor);

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
        public IActionResult ConsultarTutorPets([FromRoute] int idTutor)
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
                Endereco endereco = _tutorService.ConsultarTutorEndereco(idTutor); 

                if (endereco != null)
                    return Ok(endereco);
                else
                    return BadRequest(new ErrorResponse() { Mensagem = "Endereço ou Tutor não encontrado." }); // Acrescentar uma mensagem de erro que faça sentido
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse() { Mensagem = $"Endereço ou Tutor não encontrado.: {ex.Message}" }); // Acrescentar uma mensagem de erro que faça sentido
            }
        }

        [HttpPost("v1/endereco")]
        [ProducesResponseType(typeof(EnderecoResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        public IActionResult CadastrarEndereco([FromBody] EnderecoRequest enderecoRequest)
        {
            try
            {
                _tutorService.ValidarTutorEndereco(enderecoRequest);
                return Ok(_tutorService.CadastrarEndereco(enderecoRequest));
            }
            catch (Exception ex) { 
                return BadRequest(new ErrorResponse() { Mensagem = $"Erro ao cadastrar o endereço: {ex.Message}"});
            }
        }

        [HttpPut("v1/endereco/{id_endereco}")]
        [ProducesResponseType(typeof(SuccessResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        public IActionResult AlterarEndereco([FromRoute] int id_endereco, [FromBody] EnderecoRequest enderecoRequest)
        {
            try
            {

                bool atualizou = _tutorService.AtualizarEndereco(id_endereco, enderecoRequest);
                if (atualizou)
                {
                    return Ok(new SuccessResponse() { Mensagem = "Endereço atualizado com sucesso." });
                }
                
                return BadRequest(new ErrorResponse() { Mensagem = "Não foi possível atualizar o endereço" });
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse() { Mensagem = $"Ocorreu um erro ao tentar atualizar o endereço: {ex.Message}" });
            }            
        }

        [HttpDelete("v1/{id_tutor}")]
        [ProducesResponseType(typeof(SuccessResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        public IActionResult ExcluirTutor([FromRoute] int id_tutor)
        {
            try
            {
                bool excluiu = _tutorService.ExcluirTutor(id_tutor);
                if (excluiu)
                {
                    return Ok(new SuccessResponse() { Mensagem = "Tutor excluído com sucesso." });
                }

                return BadRequest(new ErrorResponse() { Mensagem = "Não foi possível excluir o tutor" });
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse() { Mensagem = $"Ocorreu um erro ao tentar excluir o tutor: {ex.Message}" });
            }
        }

        [HttpPost("v1/login")]
        [ProducesResponseType(typeof(SuccessResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        public IActionResult Logar([FromBody] LoginRequest loginRequest)
        {
            try
            {
                if (_tutorService.Logar(loginRequest))
                    return Ok(new SuccessResponse() { Mensagem = "Logado com sucesso." });

                return BadRequest(new ErrorResponse() { Mensagem = "Login/senha inválido."});
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse() { Mensagem = $"Erro ao efetuar o login: {ex.Message}" });
            }
        }
    }

}
