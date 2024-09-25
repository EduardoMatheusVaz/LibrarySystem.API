using LibrarySystem.Core.Entities;
using LibrarySystem.Core.Repositories;
using MediatR;

namespace LibrarySystem.Application.Commands.UpdateBook;

public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, Unit>
{
    private readonly IBookRepository _bookRepository;

    public UpdateBookCommandHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<Unit> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        var book = new Book(request.Title, request.Author, request.ISBN, request.Year, request.Synopsis, request.Gender);

        await _bookRepository.Update(request.Id, book);

        return Unit.Value;
    }
}
