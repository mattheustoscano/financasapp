using FinancasApp.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancasApp.Domain.Interfaces.Services
{
    /// <summary>
    /// Interface genérica para os serviços do domínio
    /// </summary>
    public interface IBaseService<TRequest, TResponse, TKey> : IDisposable        
    {
        Task<TResponse> AdicionarAsync(TRequest request);
        
        Task<TResponse> ModificarAsync(TKey id, TRequest request);
        
        Task<TResponse> ExcluirAsync(TKey id);

        Task<PageResult<TResponse>> ConsultarAsync(int pageNumber, int pageSize);

        Task<TResponse?> ObterPorIdAsync(TKey id);
    }
}
