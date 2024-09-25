using FluentValidation;
using LibrarySystem.Application.Commands.CreateBook;
using LibrarySystem.Application.Commands.UpdateBook;
using LibrarySystem.Core.ValueObjetc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Application.Validators.Book;

public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
{
    private readonly CreateBookCommand _createBookCommand;
    public UpdateBookCommandValidator(CreateBookCommand createBookCommand)
    {
        _createBookCommand = createBookCommand;
    }
    public UpdateBookCommandValidator()
    {

        RuleFor(p => p.Title)
            .NotEmpty()
            .WithMessage("Nome do Livro não pode ser nulo e nem vazio!")
            .MaximumLength(70)
            .WithMessage("Título do livro não é válido! Foi excedido o limite de 70 caracteres");


        RuleFor(p => p.Author)
            .NotEmpty()
            .WithMessage("Nome do Autor não pode ser nulo e nem vazio!")
            .MaximumLength(50)
            .WithMessage("Nome do autor não é válido! Foi excedido o limite de 50 caracteres");


        RuleFor(i => i.ISBN)
            .NotEmpty()
            .WithMessage("ISBN do livro não pode estar nulo e nem vazio!")
            .MaximumLength(17)
            .WithMessage("ISBN informado não é válido! Foi excedido o limite de 17 caracteres");


        RuleFor(y => y.Year)
            .LessThanOrEqualTo(2024)
            .WithMessage("Ano informado não é válido! O Ano não pode ser maior que o ano atual");


        RuleFor(s => s.Synopsis)
            .NotEmpty()
            .WithMessage("Sinopse não pode ser vazia e nem nula!")
            .MaximumLength(255)
            .WithMessage("Sinopse não é válida! Foi excedido o limite de 255 caracteres!");


        RuleFor(g => g.Gender)
            .NotEmpty()
            .WithMessage("Gênero não pode ser nulo nem branco!")
            .Must(g => GenderList.Genders.Contains(g))
            .WithMessage("Gênero inválido! O Gênero informado não corresponde aos Gêneros disponíveis existentes!");
    }
}
