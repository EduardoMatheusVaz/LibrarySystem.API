using LibrarySystem.Core.Entities;
using LibrarySystem.Core.Repositories;
using MediatR;


namespace LibrarySystem.Application.Commands.UpdateUser;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
{
    private readonly IUserRepository _userRepository;

    public UpdateUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User(request.Name, request.Email, request.Phone);

         await _userRepository.Update(request.Id, user);

        return Unit.Value;
    }
}
