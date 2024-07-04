using Microsoft.AspNetCore.Mvc;
using System.Net;
using TindogService.Controllers.Responses;
using TindogService.Interfaces;
using TindogService.Objetos;
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

        [HttpGet("v1/lista-paises")]
        [ProducesResponseType(typeof(Pais), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        public IActionResult ConsultarPaises()
        {
            try
            {
                var listaPaises = _localService.ConsultaPaises();

                if (listaPaises.Count > 0)
                    return Ok(listaPaises);
                else
                    return BadRequest(new ErrorResponse() { Mensagem = "Ocorreu um erro ao obter os Paises." });
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse() { Mensagem = $"Ocorreu um erro ao obter os Paises: {ex.Message}" });
            }
        }

        [HttpGet("v1/lista-estados")]
        [ProducesResponseType(typeof(EstadoResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        public IActionResult ConsultarEstado([FromQuery] int idPais)
        {
            try
            {
                var listaEstado = _localService.ConsultaEstados(idPais);

                if (listaEstado.Count > 0)
                    return Ok(listaEstado);
                else
                    return BadRequest(new ErrorResponse() { Mensagem = "Ocorreu um erro ao obter os estados." });
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse() { Mensagem = $"Ocorreu um erro ao obter os estados: {ex.Message}" });
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
