using Azure.Core;
using FinancasApp.Domain.Dtos.Requests;
using FinancasApp.Domain.Dtos.Responses;
using FinancasApp.Domain.Interfaces.Services;
using FinancasApp.Domain.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinancasApp.API.Controllers.V1
{
    [Route("api/v1/movimentacoes")]
    [ApiController]
    public class MovimentacoesController (IMovimentacaoService movimentacaoService) : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(MovimentacaoResponse), 201)]
        public async Task<IActionResult> PostAsync([FromBody] MovimentacaoRequest request)
        {
            var response = await movimentacaoService.AdicionarAsync(request);
            return StatusCode(201, response);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(MovimentacaoResponse), 200)]
        public async Task<IActionResult> PutAsync(Guid id, [FromBody] MovimentacaoRequest request)
        {
            var response = await movimentacaoService.ModificarAsync(id, request);
            return StatusCode(200, response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(MovimentacaoResponse), 200)]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var response = await movimentacaoService.ExcluirAsync(id);
            return StatusCode(200, response);
        }

        [HttpGet]
        [ProducesResponseType(typeof(PageResult<MovimentacaoResponse>), 200)]
        public async Task<IActionResult> GetAllAsync([FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            var response = await movimentacaoService.ConsultarAsync(pageNumber, pageSize);
            return StatusCode(200, response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(MovimentacaoResponse), 200)]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var response = await movimentacaoService.ObterPorIdAsync(id);
            return StatusCode(200, response);
        }
    }
}
