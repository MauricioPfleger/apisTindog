using Microsoft.AspNetCore.Mvc;
using System.Net;
using TindogService.Controllers.Request;
using TindogService.Controllers.Responses;
using TindogService.Interfaces;
using TindogService.Services;

namespace TindogService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PetController: ControllerBase
    {
        private readonly IPetService _petService;

        public PetController(IPetService petService)
        {
            _petService = petService;
        }
        [HttpPost("v1/pet/{id_tutor}")]
        [ProducesResponseType(typeof(SuccessResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        public IActionResult CadastrarPet([FromRoute] int id_tutor, [FromBody] PetRequest PetRequest)
        {
            try
            {
                bool atualizou = _petService.inserirPet(id_tutor, PetRequest);
                if (atualizou)
                {
                    return Ok(new SuccessResponse() { Mensagem = "Pet cadastrado com sucesso." });
                }

                return BadRequest(new ErrorResponse() { Mensagem = "Não foi possível cadastrar o pet." });
            
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse() { Mensagem = $"Erro ao cadastrar o pet: {ex.Message}" });
            }
        }
    }
}
