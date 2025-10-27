using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancasApp.Domain.Dtos.Requests
{
    /// <summary>
    /// Registro para entrada de dados de movimentação
    /// </summary>
    public record MovimentacaoRequest(
            string Nome,        //Nome da movimentação
            string Data,        //Data da movimentação
            decimal Valor,      //Valor da movimentação
            Guid CategoriaId,   //Id da categoria
            int Tipo            //Tipo (numérico)
        );
}
