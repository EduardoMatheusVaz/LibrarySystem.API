using LibrarySystem.Core.Entities;
using LibrarySystem.Core.Repositories;
using MediatR;


namespace LibrarySystem.Application.Commands.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
{
    private readonly IUserRepository _userRepository;

    public CreateUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User(request.Name, request.Email, request.Phone);

        await _userRepository.Create(user);

        return user.Id; 
    }
}
