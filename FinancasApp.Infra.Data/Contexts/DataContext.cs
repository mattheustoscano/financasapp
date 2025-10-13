using FinancasApp.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace FinancasApp.Infra.Data.Contexts
{
    public class DataContext : DbContext
    {
        //Método construtor para receber por meio de injeção de dependência configurações do banco de dados
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoriaMap());
            modelBuilder.ApplyConfiguration(new MovimentacaoMap());

            base.OnModelCreating(modelBuilder);
        }

    }
}
