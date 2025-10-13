using FinancasApp.Domain.Interfaces.Repositories;
using FinancasApp.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore.Storage;

namespace FinancasApp.Infra.Data.Repositories
{
    public class UnitOfWork(DataContext dataContext) : IUnitOfWork
    {
        private IDbContextTransaction? transaction;

        public void BeginTransaction()
        {
            if (transaction != null)
                return;

            transaction = dataContext.Database.BeginTransaction();
        }

        public void Commit()
        {
            if (transaction != null)
                transaction.Commit();
        }

        public void Rollback()
        {
            if (transaction != null)
                transaction.Rollback();
        }

        public ICategoriaRepository CategoriaRepository => new CategoriaRepository(dataContext);

        public IMovimentacaoRepository MovimentacaoRepository => new MovimentacaoRepository(dataContext);

        public void Dispose()
        {
            if (transaction != null)
                transaction.Dispose();

            dataContext.Dispose();
        }
    }
}
