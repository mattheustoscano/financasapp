using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancasApp.Domain.Utils
{
    /// <summary>
    /// Representa o resultado paginado de uma consulta.
    /// </summary>
    public class PageResult<T>
    {
        /// <summary>
        /// Coleção de itens (entidade) retornados na página atual da consulta
        /// </summary>
        public IEnumerable<T> Items { get; set; } = new List<T>();

        /// <summary>
        /// Número da página atual da consulta
        /// </summary>
        public int PageNumber { get; set; }

        /// <summary>
        /// Quantidade de registros exibidos por página
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Quantidade total de registros encontrados na consulta (sem paginação)
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// Quantidade total de páginas, calculado com base no TotalCount e PageSize
        /// </summary>
        public int TotalPages => (int) Math.Ceiling((double) TotalCount / PageSize);

        /// <summary>
        /// Indica se existe uma próxima página após a atual
        /// </summary>
        public bool HasNextPage => PageNumber < TotalPages;

        /// <summary>
        /// Indica se existe uma página anterior à atual.
        /// </summary>
        public bool HasPreviousPage => PageNumber > 1;
    }
}
