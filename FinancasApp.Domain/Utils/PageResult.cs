namespace FinancasApp.Domain.Utils
{
    /// <summary>
    /// Representa o resultado paginado de uma consulta.
    /// </summary>
    public class PageResult<TEntity>
        where TEntity : class
    {
        /// <summary>
        /// Coleção de itens da página atual.
        /// </summary>
        public IEnumerable<TEntity> Items { get; set; } = new List<TEntity>();

        /// <summary>
        /// Número da página atual.
        /// </summary>
        public int PageNumber { get; set; }

        /// <summary>
        /// Quantidade de registros exibidos por página.
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Quantidade total de registros disponíveis.
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// Quantidade total de páginas disponíveis.
        /// </summary>
        public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);

        /// <summary>
        /// Indica se existe uma página seguinte.
        /// </summary>
        public bool HasNextPage => PageNumber < TotalPages;

        /// <summary>
        /// Indica se existe uma página anterior.
        /// </summary>
        public bool HasPreviousPage => PageNumber > 1;

    }
}
