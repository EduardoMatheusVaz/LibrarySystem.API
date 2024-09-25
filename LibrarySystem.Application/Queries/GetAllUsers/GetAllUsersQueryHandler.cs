using LibrarySystem.Application.ViewModels;
using LibrarySystem.Core.Repositories;
using MediatR;


namespace LibrarySystem.Application.Queries.GetAllUsers;

public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<UserViewModel>>
{
    private readonly IUserRepository _userRepository;

    public GetAllUsersQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<List<UserViewModel>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var users =  await _userRepository.GetAllAsync();

        var usersViewModel = users.Select(x => new UserViewModel(
            x.Id,
            x.Name,
            x.Email,
            x.Phone
            )).ToList();

        return usersViewModel;
    }
}
