using MediatR;


namespace LibrarySystem.Application.Commands.UpdateUser;

public class UpdateUserCommand : IRequest<Unit>
{
    public UpdateUserCommand(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
}
