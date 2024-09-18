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

namespace LibrarySystem.Application.Commands.DeleteUser;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Unit>
{
    private readonly IUserRepository _userRepository;
    private readonly LibrarySystemDbContext _dbcontext;

    public DeleteUserCommandHandler(IUserRepository userRepository, LibrarySystemDbContext dbcontext)
    {
        _userRepository = userRepository;
        _dbcontext = dbcontext;
    }

    public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        await _userRepository.Delete(request.Id);

        await _dbcontext.SaveChangesAsync();

        return Unit.Value;
    }
}
