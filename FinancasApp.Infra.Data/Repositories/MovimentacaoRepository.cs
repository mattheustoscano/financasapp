using FinancasApp.Domain.Entities;
using FinancasApp.Domain.Interfaces.Repositories;
using FinancasApp.Infra.Data.Contexts;

namespace FinancasApp.Infra.Data.Repositories
{
    public class MovimentacaoRepository(DataContext dataContext)
        : BaseRepository<Movimentacao, Guid>(dataContext), IMovimentacaoRepository
    {

    }
}
