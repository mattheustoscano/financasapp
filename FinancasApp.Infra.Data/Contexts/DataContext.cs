using FinancasApp.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace FinancasApp.Infra.Data.Contexts
{
    public class DataContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoriaMap());
            modelBuilder.ApplyConfiguration(new MovimentacaoMap());

            base.OnModelCreating(modelBuilder);
        }

    }
}
