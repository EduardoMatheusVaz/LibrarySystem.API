using LibrarySystem.Core.Repositories;
using MediatR;


namespace LibrarySystem.Application.Commands.BooksAvailable;

public class BooksAvailableCommandHandler : IRequestHandler<BooksAvailableCommand, Unit>
{
    private readonly IBookRepository _bookRepository;

    public BooksAvailableCommandHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<Unit> Handle(BooksAvailableCommand request, CancellationToken cancellationToken)
    {
        await _bookRepository.Available(request.Id);

        return Unit.Value;
    }
}
