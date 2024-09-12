using LibrarySystem.Core.Repositories;
using LibrarySystem.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Application.Commands.BookRented;

public class BookRentedCommandHandler : IRequestHandler<BookRentedCommand, Unit>
{
    private readonly IBookRepository _bookRepository;

    public BookRentedCommandHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<Unit> Handle(BookRentedCommand request, CancellationToken cancellationToken)
    {
        await _bookRepository.Rented(request.Id);

        return Unit.Value;
    }
}
