using Dapper;
using LibrarySystem.Core.Repositories;
using LibrarySystem.Infrastructure.Persistence;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
