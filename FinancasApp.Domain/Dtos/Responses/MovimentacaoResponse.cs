using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancasApp.Domain.Dtos.Responses
{
    /// <summary>
    /// Registro para saída de dados de movimentação
    /// </summary>
    public record MovimentacaoResponse(
            Guid Id,        //Id da movimentação
            string Nome,    //Nome da movimentação
            string Data,    //Data da movimentação
            decimal Valor,  //Valor da movimentação
            int Tipo,       //Tipo da movimentação
            CategoriaResponse Categoria //Dados da categoria
        );
}
