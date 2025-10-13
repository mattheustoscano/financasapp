using Bogus;
using FinancasApp.Domain.Entities;
using FinancasApp.Domain.Interfaces.Repositories;
using FinancasApp.Infra.Data.Repositories;
using FinancasApp.Infra.Data.Test.Contexts;
using FluentAssertions;

namespace FinancasApp.Infra.Data.Tests.Facts
{
    public class MovimentacaoRepositoryFact
    {
        private readonly Faker<Categoria> _fakerCategoria;
        private readonly Faker<Movimentacao> _fakerMovimentacao;
        private readonly IUnitOfWork _unitOfWork;

        public MovimentacaoRepositoryFact()
        {
            _fakerCategoria = new Faker<Categoria>("pt_BR")
                .RuleFor(c => c.Id, f => Guid.NewGuid())
                .RuleFor(c => c.Nome, f => f.Commerce.Categories(1).First());

            _fakerMovimentacao = new Faker<Movimentacao>("pt_BR")
                .RuleFor(m => m.Id, f => Guid.NewGuid())
                .RuleFor(m => m.Nome, f => f.Commerce.Product())
                .RuleFor(m => m.Data, f => DateOnly.FromDateTime(DateTime.Now))
                .RuleFor(m => m.Valor, f => (double)f.Random.Decimal(10, 1000))
                .RuleFor(m => m.Tipo, f => f.PickRandom<TipoMovimentacao>());

            _unitOfWork = new UnitOfWork(TestContext.CreateDataContext());
        }

        [Fact(DisplayName = "Adicionar movimentação com sucesso no banco de dados.")]
        public async Task AdicionarMovimentacaoComSucesso()
        {
            var categoria = _fakerCategoria.Generate();
            await _unitOfWork.CategoriaRepository.AddAsync(categoria);

            var movimentacao = _fakerMovimentacao.Generate();
            movimentacao.CategoriaId = categoria.Id;

            await _unitOfWork.MovimentacaoRepository.AddAsync(movimentacao);

            var registro = await _unitOfWork.MovimentacaoRepository.GetByIdAsync(movimentacao.Id);
            registro.Should().NotBeNull();
            registro.Id.Should().Be(movimentacao.Id);
            registro.Nome.Should().Be(movimentacao.Nome);
            registro.Data.Should().Be(movimentacao.Data);
            registro.Valor.Should().Be(movimentacao.Valor);
            registro.Tipo.Should().Be(movimentacao.Tipo);
            registro.CategoriaId.Should().Be(movimentacao.CategoriaId);
        }

        [Fact(DisplayName = "Atualizar movimentação com sucesso no banco de dados.")]
        public async Task AtualizarMovimentacaoComSucesso()
        {
            var categoria = _fakerCategoria.Generate();
            await _unitOfWork.CategoriaRepository.AddAsync(categoria);

            var movimentacao = _fakerMovimentacao.Generate();
            movimentacao.CategoriaId = categoria.Id;
            await _unitOfWork.MovimentacaoRepository.AddAsync(movimentacao);

            movimentacao.Nome = "Movimentação Atualizada";
            movimentacao.Valor = 999.99;
            movimentacao.Tipo = TipoMovimentacao.Receber;

            await _unitOfWork.MovimentacaoRepository.UpdateAsync(movimentacao);

            var registro = await _unitOfWork.MovimentacaoRepository.GetByIdAsync(movimentacao.Id);
            registro.Should().NotBeNull();
            registro.Nome.Should().Be("Movimentação Atualizada");
            registro.Valor.Should().Be(999.99);
            registro.Tipo.Should().Be(TipoMovimentacao.Receber);
        }

        [Fact(DisplayName = "Excluir movimentação com sucesso no banco de dados.")]
        public async Task ExcluirMovimentacaoComSucesso()
        {
            var categoria = _fakerCategoria.Generate();
            await _unitOfWork.CategoriaRepository.AddAsync(categoria);

            var movimentacao = _fakerMovimentacao.Generate();
            movimentacao.CategoriaId = categoria.Id;
            await _unitOfWork.MovimentacaoRepository.AddAsync(movimentacao);

            await _unitOfWork.MovimentacaoRepository.DeleteAsync(movimentacao);

            var registro = await _unitOfWork.MovimentacaoRepository.GetByIdAsync(movimentacao.Id);
            registro.Should().BeNull();
        }

        [Fact(DisplayName = "Consultar movimentações com sucesso no banco de dados.")]
        public async Task ConsultarMovimentacoesComSucesso()
        {
            var categoria = _fakerCategoria.Generate();
            await _unitOfWork.CategoriaRepository.AddAsync(categoria);

            var movimentacoes = _fakerMovimentacao.Generate(3);
            foreach (var mov in movimentacoes)
            {
                mov.CategoriaId = categoria.Id;
                await _unitOfWork.MovimentacaoRepository.AddAsync(mov);
            }

            var registros = await _unitOfWork.MovimentacaoRepository.GetAllAsync();
            registros.Should().NotBeEmpty();
            registros.Should().HaveCountGreaterThanOrEqualTo(3);
        }

        [Fact(DisplayName = "Obter movimentação por id com sucesso no banco de dados.")]
        public async Task ObterMovimentacaoPorIdComSucesso()
        {
            var categoria = _fakerCategoria.Generate();
            await _unitOfWork.CategoriaRepository.AddAsync(categoria);

            var movimentacao = _fakerMovimentacao.Generate();
            movimentacao.CategoriaId = categoria.Id;
            await _unitOfWork.MovimentacaoRepository.AddAsync(movimentacao);

            var registro = await _unitOfWork.MovimentacaoRepository.GetByIdAsync(movimentacao.Id);
            registro.Should().NotBeNull();
            registro.Id.Should().Be(movimentacao.Id);
        }
    }
}



