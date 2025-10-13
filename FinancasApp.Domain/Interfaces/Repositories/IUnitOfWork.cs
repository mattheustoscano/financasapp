namespace FinancasApp.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        #region Operações de transação

        void BeginTransaction();
        void Commit();
        void Rollback();

        #endregion

        #region Acesso aos repositórios

        public ICategoriaRepository CategoriaRepository { get; }
        public IMovimentacaoRepository MovimentacaoRepository { get; }

        #endregion
    }
}
