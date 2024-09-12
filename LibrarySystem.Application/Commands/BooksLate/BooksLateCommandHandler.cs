using LibrarySystem.Core.Repositories;
using LibrarySystem.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Application.Commands.BooksLate;

public class BooksLateCommandHandler : IRequestHandler<BooksLateCommand, Unit>
{
    private readonly IBookRepository _bookRepository;

    public BooksLateCommandHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<Unit> Handle(BooksLateCommand request, CancellationToken cancellationToken)
    {
        await _bookRepository.Late(request.Id);

        return Unit.Value;
    }
}
