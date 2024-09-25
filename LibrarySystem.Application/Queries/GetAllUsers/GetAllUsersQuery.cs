using LibrarySystem.Application.ViewModels;
using MediatR;


namespace LibrarySystem.Application.Queries.GetAllUsers;

public class GetAllUsersQuery : IRequest<List<UserViewModel>>
{
    public string Name { get; set; }
    public string Email { get; set; }
    public int Phone { get; set; }
}
