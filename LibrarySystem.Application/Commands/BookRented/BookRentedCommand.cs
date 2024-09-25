using MediatR;


namespace LibrarySystem.Application.Commands.BookRented;

public class BookRentedCommand : IRequest<Unit>
{
    public BookRentedCommand(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}
