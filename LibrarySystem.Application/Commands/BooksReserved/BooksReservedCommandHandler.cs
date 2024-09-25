using LibrarySystem.Core.Repositories;
using MediatR;


namespace LibrarySystem.Application.Commands.BooksReserved;

public class BooksReservedCommandHandler : IRequestHandler<BooksReservedCommand, Unit>
{
    private readonly IBookRepository _bookRepository;

    public BooksReservedCommandHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<Unit> Handle(BooksReservedCommand request, CancellationToken cancellationToken)
    {
        await _bookRepository.Reserved(request.Id);

        return Unit.Value;
    }
}
