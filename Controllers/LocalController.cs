using Microsoft.AspNetCore.Mvc;
using System.Net;
using TindogService.Controllers.Responses;
using TindogService.Interfaces;
using TindogService.Services;

namespace TindogService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LocalController : ControllerBase
    {
        private readonly ILocalService _localService;

        public LocalController(ILocalService localService)
        {
            _localService = localService;
        }

        // Acrescentar cada 1 a sua API

        [HttpGet("v1/lista-cidades")]
        [ProducesResponseType(typeof(CidadeResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        public IActionResult ConsultarCidade()
        {
            try
            {
                var listCidade = _localService.ConsultaCidades();

                if (listCidade.Count > 0)
                    return Ok(listCidade);
                else
                    return BadRequest(new ErrorResponse() { Mensagem = "Ocorreu um erro ao obter os pets do tutor." });
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse() { Mensagem = $"Ocorreu um erro ao obter os pets do tutor: {ex.Message}" });
            }
        }
    }
}
