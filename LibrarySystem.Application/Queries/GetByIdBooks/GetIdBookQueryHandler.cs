using LibrarySystem.Application.ViewModels;
using LibrarySystem.Core.Repositories;
using MediatR;


namespace LibrarySystem.Application.Queries.GetByIdBooks;

public class GetIdBookQueryHandler : IRequestHandler<GetIdBookQuery, BookParticularityViewModel>
{
    private readonly IBookRepository _bookRepository;

    public GetIdBookQueryHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<BookParticularityViewModel> Handle(GetIdBookQuery request, CancellationToken cancellationToken)
    {
        var book = await _bookRepository.GetByIdAsync(request.Id);

        var bookParticularity = new BookParticularityViewModel(book.Id, book.Title, book.Author, book.ISBN, book.Year, book.Synopsis, book.Gender, book.Status);

        return bookParticularity;
    }
}
