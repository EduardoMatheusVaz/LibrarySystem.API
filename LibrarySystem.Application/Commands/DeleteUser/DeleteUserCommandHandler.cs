using Dapper;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Application.Commands.DeleteUser;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Unit>
{
    private readonly string _connectionstring;

    public DeleteUserCommandHandler(IConfiguration configuration)
    {
        _connectionstring = configuration.GetConnectionString("DataBase");
    }

    public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        using ( var sqlConnection = new SqlConnection(_connectionstring))
        {
            sqlConnection.Open();

            var script = "DELETE FROM tb_User WHERE Id = @Id";

            await sqlConnection.ExecuteAsync(script, new { Id = request.Id});

            return Unit.Value;
        }
    }
}
