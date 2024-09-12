using LibrarySystem.Core.Repositories;
using LibrarySystem.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Application.Commands.UserOff;

public class UserOffCommandHandler : IRequestHandler<UserOffCommand, Unit>
{
    private readonly IUserRepository _userRepository;

    public UserOffCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Unit> Handle(UserOffCommand request, CancellationToken cancellationToken)
    {
        await _userRepository.Off(request.Id);

        return Unit.Value;
    }
}

