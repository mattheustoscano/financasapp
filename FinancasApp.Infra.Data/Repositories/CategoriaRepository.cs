using FinancasApp.Domain.Entities;
using FinancasApp.Domain.Interfaces.Repositories;
using FinancasApp.Infra.Data.Contexts;

namespace FinancasApp.Infra.Data.Repositories
{
    public class CategoriaRepository (DataContext dataContext) 
        : BaseRepository<Categoria, Guid>(dataContext), ICategoriaRepository
    {


    }
}
