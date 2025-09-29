using FinancasApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinancasApp.Infra.Data.Mappings
{
    public class CategoriaMap : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("CATEGORIA"); //nome da tabela

            builder.HasKey(x => x.Id); //chave primária

            builder.Property(c => c.Id).HasColumnName("ID"); //campo
            builder.Property(c => c.Nome).HasColumnName("NOME").HasMaxLength(50); //campo

            builder.HasIndex(c => c.Nome).IsUnique(); //indice para campo unico
        }
    }
}
