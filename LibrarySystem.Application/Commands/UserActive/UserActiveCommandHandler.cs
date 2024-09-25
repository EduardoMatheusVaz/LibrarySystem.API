using LibrarySystem.Core.Repositories;
using MediatR;


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
