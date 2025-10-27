using AutoMapper;
using FinancasApp.Domain.Dtos.Requests;
using FinancasApp.Domain.Dtos.Responses;
using FinancasApp.Domain.Entities;
using FinancasApp.Domain.Interfaces.Repositories;
using FinancasApp.Domain.Interfaces.Services;
using FinancasApp.Domain.Utils;
using FinancasApp.Domain.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancasApp.Domain.Services
{
    /// <summary>
    /// Implementação dos serviços de domínio da entidade Movimentação
    /// </summary>
    public class MovimentacaoService (IUnitOfWork unitOfWork, IMapper mapper) : IMovimentacaoService
    {
        public async Task<MovimentacaoResponse> AdicionarAsync(MovimentacaoRequest request)
        {
            var anyCategoria = await unitOfWork.CategoriaRepository.AnyAsync(c => c.Id.Equals(request.CategoriaId));
            if (!anyCategoria)
                throw new KeyNotFoundException("Categoria não encontrada.");

            var movimentacao = mapper.Map<Movimentacao>(request);

            var validator = new MovimentacaoValidator();
            var result = validator.Validate(movimentacao);

            if (!result.IsValid)
                throw new ValidationException(result.Errors);

            await unitOfWork.MovimentacaoRepository.AddAsync(movimentacao);

            return mapper.Map<MovimentacaoResponse>
                (await unitOfWork.MovimentacaoRepository.GetByIdAsync(movimentacao.Id));
        }

        public async Task<MovimentacaoResponse> ModificarAsync(Guid id, MovimentacaoRequest request)
        {
            var anyCategoria = await unitOfWork.CategoriaRepository.AnyAsync(c => c.Id.Equals(request.CategoriaId));
            if (!anyCategoria)
                throw new KeyNotFoundException("Categoria não encontrada.");

            var movimentacao = await unitOfWork.MovimentacaoRepository.GetByIdAsync(id);
            if(movimentacao == null)
                throw new KeyNotFoundException("Movimentação não encontrada.");

            mapper.Map(request, movimentacao);

            var validator = new MovimentacaoValidator();
            var result = validator.Validate(movimentacao);

            if (!result.IsValid)
                throw new ValidationException(result.Errors);

            await unitOfWork.MovimentacaoRepository.UpdateAsync(movimentacao);

            return mapper.Map<MovimentacaoResponse>(movimentacao);
        }

        public async Task<MovimentacaoResponse> ExcluirAsync(Guid id)
        {
            var movimentacao = await unitOfWork.MovimentacaoRepository.GetByIdAsync(id);
            if (movimentacao == null)
                throw new KeyNotFoundException("Movimentação não encontrada.");

            await unitOfWork.MovimentacaoRepository.DeleteAsync(movimentacao);

            return mapper.Map<MovimentacaoResponse>(movimentacao);
        }

        public async Task<PageResult<MovimentacaoResponse>> ConsultarAsync(int pageNumber, int pageSize)
        {
            if (pageNumber <= 0) pageNumber = 1;
            if (pageSize <= 0 || pageSize > 25) pageSize = 25;

            var pageResult = await unitOfWork.MovimentacaoRepository.GetAllAsync(pageNumber, pageSize);

            var response = new PageResult<MovimentacaoResponse>
            {
                Items = mapper.Map<List<MovimentacaoResponse>>(pageResult.Items),
                PageNumber = pageResult.PageNumber,
                PageSize = pageResult.PageSize,
                TotalCount = pageResult.TotalCount
            };

            return response;
        }

        public async Task<MovimentacaoResponse?> ObterPorIdAsync(Guid id)
        {
            var movimentacao = await unitOfWork.MovimentacaoRepository.GetByIdAsync(id);
            if (movimentacao == null)
                return null;

            return mapper.Map<MovimentacaoResponse>(movimentacao);
        }

        public void Dispose()
        {
            unitOfWork.Dispose();
        }
    }
}
