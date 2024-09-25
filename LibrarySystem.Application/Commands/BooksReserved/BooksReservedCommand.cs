using MediatR;


namespace LibrarySystem.Application.Commands.BooksReserved;

public class BooksReservedCommand : IRequest<Unit>
{
    public BooksReservedCommand(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}
