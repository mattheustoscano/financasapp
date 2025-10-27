using FinancasApp.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancasApp.Domain.Validators
{
    public class MovimentacaoValidator : AbstractValidator<Movimentacao>
    {
        public MovimentacaoValidator()
        {
            RuleFor(c => c.Nome)
                .NotEmpty()
                .WithMessage("O nome da movimentação é obrigatório.")
                .Length(6, 150)
                .WithMessage("O nome da movimentação deve ter de 6 a 150 caracteres.");

            RuleFor(c => c.Data)
                .NotNull()
                .WithMessage("A data da movimentação é obrigatória.")
                .LessThanOrEqualTo(_ => DateOnly.FromDateTime(DateTime.Now))
                .WithMessage("A data da movimentação deve ser menor ou igual a data atual.");

            RuleFor(c => c.Valor)
                .NotNull()
                .WithMessage("O valor da movimentação é obrigatório.")
                .GreaterThan(0)
                .WithMessage("O valor da movimentação deve ser maior do que zero.");

            RuleFor(c => c.CategoriaId)
                .NotNull()
                .WithMessage("O ID da categoria é obrigatório.");

            RuleFor(c => c.Tipo)
                .NotNull()
                .WithMessage("O tipo da movimentação é obrigatório.");
        }
    }
}
