 using Dapper;
using LibrarySystem.Core.Repositories;
using LibrarySystem.Infrastructure.Persistence;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
