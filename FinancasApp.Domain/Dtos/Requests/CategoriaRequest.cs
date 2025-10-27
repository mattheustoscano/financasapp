using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancasApp.Domain.Dtos.Requests
{
    /// <summary>
    /// Registro para entrada de dados de categoria
    /// </summary>
    public record CategoriaRequest(
            string Nome //Nome da categoria
        );
}
