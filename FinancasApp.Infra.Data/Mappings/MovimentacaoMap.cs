using FinancasApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinancasApp.Infra.Data.Mappings
{
    public class MovimentacaoMap : IEntityTypeConfiguration<Movimentacao>
    {
        public void Configure(EntityTypeBuilder<Movimentacao> builder)
        {
            builder.ToTable("MOVIMENTACAO");

            builder.HasKey(m => m.Id); //chave primaria

            builder.Property(m => m.Id).HasColumnName("ID");
            builder.Property(m => m.Nome).HasColumnName("NOME").HasMaxLength(150);
            builder.Property(m => m.Data).HasColumnName("DATA").HasColumnType("date");
            builder.Property(m => m.Valor).HasColumnName("VALOR").HasColumnType("decimal(10,2)");
            builder.Property(m => m.Tipo).HasColumnName("TIPO");
            builder.Property(m => m.CategoriaId).HasColumnName("CATEGORIA_ID");

            //mapeamento do relacionamento
            builder.HasOne(m => m.Categoria) //Movimentaçao tem uma Categoria
                   .WithMany(c => c.Movimentacoes) //Categoria tem muitas Movimentações
                   .HasForeignKey(m => m.CategoriaId) //Chave estrangeira em Movimentacao
                   .OnDelete(DeleteBehavior.Restrict); //Não deletar movimentações ao deletar categoria


        }
    }
}
