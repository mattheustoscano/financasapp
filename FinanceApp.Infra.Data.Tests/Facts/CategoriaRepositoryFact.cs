using Bogus;
using FinancasApp.Domain.Entities;
using FinancasApp.Domain.Interfaces.Repositories;
using FinancasApp.Infra.Data.Repositories;
using FinancasApp.Infra.Data.Test.Contexts;
using FluentAssertions;

namespace FinancasApp.Infra.Data.Tests.Facts
{
    public class CategoriaRepositoryFact
    {
        //Atributos
        private readonly Faker<Categoria> _fakerCategoria;
        private readonly IUnitOfWork _unitOfWork;

        //Construtor
        public CategoriaRepositoryFact()
        {
            //Criado um registro de categoria
            _fakerCategoria = new Faker<Categoria>("pt_BR")
                .RuleFor(c => c.Id, f => Guid.NewGuid())
                .RuleFor(c => c.Nome, f => f.Commerce.Categories(1).First());

            //Inicializando o Unit of Work
            _unitOfWork = new UnitOfWork(TestContext.CreateDataContext());
        }

        [Fact(DisplayName = "Adicionar categoria com sucesso no banco de dados.")]
        public async Task AdicionarCategoriaComSucesso()
        {
            //Arrange
            var categoria = _fakerCategoria?.Generate();

            //Act
            await _unitOfWork.CategoriaRepository.AddAsync(categoria);

            //Assert
            var registro = await _unitOfWork.CategoriaRepository.GetByIdAsync(categoria.Id);
            Assert.NotNull(registro);

            registro.Id.Should().Be(categoria.Id);
            registro.Nome.Should().Be(categoria.Nome);
        }

        [Fact(DisplayName = "Atualizar categoria com sucesso no banco de dados.")]
        public async Task AtualizarCategoriaComSucesso()
        {
            //Arrange
            var categoria = _fakerCategoria?.Generate();
            await _unitOfWork.CategoriaRepository.AddAsync(categoria);
            categoria.Nome = "Nome teste";

            //Act
            await _unitOfWork.CategoriaRepository.UpdateAsync(categoria);

            //Assert
            var registro = await _unitOfWork.CategoriaRepository.GetByIdAsync(categoria.Id);
            Assert.NotNull(registro);

            registro.Id.Should().Be(categoria.Id);
            registro.Nome.Should().Be(categoria.Nome);
        }

        [Fact(DisplayName = "Excluir categoria com sucesso no banco de dados.")]
        public async Task ExcluirCategoriaComSucesso()
        {
            //Arrange
            var categoria = _fakerCategoria?.Generate();
            await _unitOfWork.CategoriaRepository.AddAsync(categoria);

            //Act
            await _unitOfWork.CategoriaRepository.DeleteAsync(categoria);

            //Assert
            var registro = await _unitOfWork.CategoriaRepository.GetByIdAsync(categoria.Id);
            Assert.Null(registro);
        }

        [Fact(DisplayName = "Consultar categorias com sucesso no banco de dados.")]
        public async Task ConsultarCategoriasComSucesso()
        {
            //Arrange
            for (int i = 1; i <= 5; i++)
            {
                var categoria = _fakerCategoria?.Generate();
                await _unitOfWork.CategoriaRepository.AddAsync(categoria);
            }

            //Act
            var categorias = await _unitOfWork.CategoriaRepository.GetAllAsync();

            //Assert
            Assert.NotNull(categorias);
            categorias.Should().HaveCountGreaterThanOrEqualTo(5);
        }

        [Fact(DisplayName = "Obter categoria por id com sucesso no banco de dados.")]
        public async Task ObterCategoriaPorIdComSucesso()
        {
            //Arrange
            var categoria = _fakerCategoria?.Generate();
            await _unitOfWork.CategoriaRepository.AddAsync(categoria);

            //Act
            var registro = await _unitOfWork.CategoriaRepository.GetByIdAsync(categoria.Id);

            //Assert
            Assert.NotNull(registro);

            registro.Id.Should().Be(categoria.Id);
            registro.Nome.Should().Be(categoria.Nome);
        }
    }
}



