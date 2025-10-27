using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancasApp.Domain.Dtos.Responses
{
    /// <summary>
    /// Registro para saída de dados de categoria
    /// </summary>
    public record CategoriaResponse(
            Guid Id,        //Id da categoria
            string Nome     //Nome da categoria
        );
}
