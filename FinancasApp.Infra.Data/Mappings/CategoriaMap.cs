using FinancasApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancasApp.Infra.Data.Mappings
{
    public class CategoriaMap : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("CATEGORIA"); //nome da tabela

            builder.HasKey(c => c.Id); //chave primária

            builder.Property(c => c.Id).HasColumnName("ID"); //campo
            builder.Property(c => c.Nome).HasColumnName("NOME").HasMaxLength(50); //campo

            builder.HasIndex(c => c.Nome).IsUnique(); //índice para campo único
        }
    }
}
