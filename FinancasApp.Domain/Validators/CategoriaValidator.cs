using FinancasApp.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancasApp.Domain.Validators
{
    public class CategoriaValidator : AbstractValidator<Categoria>
    {
        public CategoriaValidator()
        {
            RuleFor(c => c.Nome)
                .NotEmpty()
                .WithMessage("O nome da categoria é obrigatório.")
                .Length(6, 50)
                .WithMessage("O nome da categoria deve ter de 6 a 50 caracteres.");
        }
    }
}
