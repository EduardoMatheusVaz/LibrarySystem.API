using MediatR;


namespace LibrarySystem.Application.Commands.LoanReserved;

public class LoanReservedCommand : IRequest<Unit>
{
    public LoanReservedCommand(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}
