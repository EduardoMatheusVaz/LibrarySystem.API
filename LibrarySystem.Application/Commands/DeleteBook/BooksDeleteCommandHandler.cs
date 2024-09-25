using LibrarySystem.Core.Repositories;
using MediatR;


namespace LibrarySystem.Application.Commands.BooksDelete;

internal class BooksDeleteCommandHandler : IRequestHandler<BooksDeleteCommand, Unit>
{
    private readonly IBookRepository _bookRepository;

    public BooksDeleteCommandHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<Unit> Handle(BooksDeleteCommand request, CancellationToken cancellationToken)
    {
        await _bookRepository.Delete(request.Id);

        return Unit.Value;
    }
}
