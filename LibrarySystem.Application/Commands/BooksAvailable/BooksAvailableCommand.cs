using MediatR;


namespace LibrarySystem.Application.Commands.BooksAvailable;

public class BooksAvailableCommand : IRequest<Unit>
{
    public BooksAvailableCommand(int id)
    {
        Id = id;
    }

    public int Id { get; private set; }

}
