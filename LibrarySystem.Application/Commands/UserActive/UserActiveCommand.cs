using MediatR;


namespace LibrarySystem.Application.Commands.UserActive;

public class UserActiveCommand : IRequest<Unit>
{
    public UserActiveCommand(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}
