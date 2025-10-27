using FinancasApp.Domain.Dtos.Requests;
using FinancasApp.Domain.Dtos.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancasApp.Domain.Interfaces.Services
{
    /// <summary>
    /// Interface específica para serviços de movimentação
    /// </summary>
    public interface IMovimentacaoService
        : IBaseService<MovimentacaoRequest, MovimentacaoResponse, Guid>
    {

    }
}
