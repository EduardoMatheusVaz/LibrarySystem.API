using FluentValidation;
using LibrarySystem.Application.Commands.CreateUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Application.Validators.User;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {

        RuleFor(n => n.Name)
            .NotEmpty()
            .WithMessage("Nome não pode ser nulo nem vazio!")
            .MaximumLength(60)
            .WithMessage("Nome inválido! Foi excedido o limite de 60 caracteres");


        RuleFor(n => n.Email)
            .NotEmpty()
            .WithMessage("Email não pode ser vazio nem nulo")
            .EmailAddress()
            .WithMessage("Email informado não é válido!")
            .MaximumLength(60)
            .WithMessage("Email não é válido! Foi excedido o limite de 60 caracteres");


        RuleFor(p => p.Phone)
            .NotEmpty()
            .WithMessage("Telefone não pode ser nulo e nem vazio");
    }
}
