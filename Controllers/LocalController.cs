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

        [HttpGet("v1/{lista-estados")]
        [ProducesResponseType(typeof(EstadoResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        public IActionResult ConsultarEstado()
        {
            try
            {
                var listaEstado = _localService.ConsultaEstados();

                if (listaEstado.Count > 0)
                    return Ok(listaEstado);
                else
                    return BadRequest(new ErrorResponse() { Mensagem = "Ocorreu um erro ao obter os pets do tutor." });
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse() { Mensagem = $"Ocorreu um erro ao obter os pets do tutor: {ex.Message}" });
            }
        }

        // Acrescentar cada 1 a sua API

        [HttpGet("v1/lista-cidades")]
        [ProducesResponseType(typeof(List<CidadeResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        public IActionResult ConsultarCidade()
        {
            try
            {
                var listCidade = _localService.ConsultaCidades();

                if (listCidade.Count > 0)
                    return Ok(listCidade);
                else
                    return BadRequest(new ErrorResponse() { Mensagem = "Ocorreu um erro ao obter as cidades." });
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse() { Mensagem = $"Ocorreu um erro ao obter as cidades: {ex.Message}" });
            }
        }
    }
}
