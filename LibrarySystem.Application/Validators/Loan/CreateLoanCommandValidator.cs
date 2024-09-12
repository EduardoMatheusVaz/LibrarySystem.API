using FluentValidation;
using LibrarySystem.Application.Commands.CreateLoan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Application.Validators.Loan;

public class CreateLoanCommandValidator : AbstractValidator<CreateLoanCommand>
{

    public CreateLoanCommandValidator()
    {

        RuleFor(u => u.UserId)
            .NotEmpty()
            .WithMessage("Id do Usuário não pode ser nula nem vazia");


         RuleFor(b => b.BookId)
            .NotEmpty()
            .WithMessage("Id do Livro não pode ser nulo nem vazio!");
    }

}