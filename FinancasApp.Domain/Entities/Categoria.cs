namespace FinancasApp.Domain.Entities
{
    public class Categoria
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nome { get; set; } = string.Empty;

        public ICollection<Movimentacao>? Movimentacoes { get; set; }

    }
}
