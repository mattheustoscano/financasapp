using Azure.Core;
using FinancasApp.Domain.Dtos.Requests;
using FinancasApp.Domain.Dtos.Responses;
using FinancasApp.Domain.Interfaces.Services;
using FinancasApp.Domain.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinancasApp.API.Controllers.V1
{
    [Route("api/v1/categorias")]
    [ApiController]
    public class CategoriasController (ICategoriaService categoriaService) : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(CategoriaResponse), 201)]
        public async Task<IActionResult> PostAsync([FromBody] CategoriaRequest request)
        {
            var response = await categoriaService.AdicionarAsync(request);
            return StatusCode(201, response);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(CategoriaResponse), 200)]
        public async Task<IActionResult> PutAsync(Guid id, [FromBody] CategoriaRequest request)
        {
            var response = await categoriaService.ModificarAsync(id, request);
            return StatusCode(200, response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(CategoriaResponse), 200)]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var response = await categoriaService.ExcluirAsync(id);
            return StatusCode(200, response);
        }

        [HttpGet]
        [ProducesResponseType(typeof(PageResult<CategoriaResponse>), 200)]
        public async Task<IActionResult> GetAllAsync([FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            var response = await categoriaService.ConsultarAsync(pageNumber, pageSize);
            return StatusCode(200, response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CategoriaResponse), 200)]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var response = await categoriaService.ObterPorIdAsync(id);
            return StatusCode(200, response);
        }
    }
}
