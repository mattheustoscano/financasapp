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
    public class MovimentacaoMap : IEntityTypeConfiguration<Movimentacao>
    {
        public void Configure(EntityTypeBuilder<Movimentacao> builder)
        {
            builder.ToTable("MOVIMENTACAO"); //nome da tabela

            builder.HasKey(m => m.Id); //chave primária

            builder.Property(m => m.Id).HasColumnName("ID");
            builder.Property(m => m.Nome).HasColumnName("NOME").HasMaxLength(150);
            builder.Property(m => m.Data).HasColumnName("DATA").HasColumnType("date");
            builder.Property(m => m.Valor).HasColumnName("VALOR").HasColumnType("decimal(10,2)");
            builder.Property(m => m.Tipo).HasColumnName("TIPO");
            builder.Property(m => m.CategoriaId).HasColumnName("CATEGORIA_ID");

            //mapeamento do relacionamento
            builder.HasOne(m => m.Categoria) //Movimentação TEM 1 Categoria
                .WithMany(c => c.Movimentacoes) //Categoria TEM MUITAS Movimentações
                .HasForeignKey(m => m.CategoriaId) //Chave estrangeira
                .OnDelete(DeleteBehavior.Restrict); //Não permite excluir de houver registros relacionados
        }
    }
}
