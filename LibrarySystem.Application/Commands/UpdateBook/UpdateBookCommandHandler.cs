using Dapper;
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

namespace LibrarySystem.Application.Commands.UpdateBook;

public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, Unit>
{
    private readonly string _connectionstring;

    public UpdateBookCommandHandler(IConfiguration configuration)
    {
        _connectionstring = configuration.GetConnectionString("DataBase");
    }

    public async Task<Unit> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        {
            using (var sqlConnection = new SqlConnection(_connectionstring))
            {
                sqlConnection.Open();

                var script = "UPDATE tb_Book SET Title = @Title, Author = @Author, ISBN = @ISBN, Year = @Year, Synopsis = @Synopsis WHERE Id = @Id";

                await sqlConnection.ExecuteAsync(script, new {Title = request.Title, Author = request.Author, ISBN = request.ISBN, Year = request.Year, Synopsis = request.Synopsis, Id = request.Id});

                return Unit.Value;
            }
        }
    }
}
