using LibrarySystem.Core.Repositories;
using LibrarySystem.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Application.Commands.UserActive;

public class UserActiveCommandHandler : IRequestHandler<UserActiveCommand, Unit>
{
    private readonly IUserRepository _userRepository;

    public UserActiveCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Unit> Handle(UserActiveCommand request, CancellationToken cancellationToken)
    {
        await _userRepository.Active(request.Id);
        
        return Unit.Value;
    }
}
