using LibrarySystem.Core.Entities;
using LibrarySystem.Core.Repositories;
using MediatR;

namespace LibrarySystem.Application.Commands.CreateBook;

public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, int>
{
    private readonly IBookRepository _bookRepository;

    public CreateBookCommandHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        var createBook = new Book(request.Title, request.Author, request.ISBN, request.Year, request.Synopsis, request.Gender);

        await _bookRepository.Create(createBook);

        return createBook.Id;
    }
}
