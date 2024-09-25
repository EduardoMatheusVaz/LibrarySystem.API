using MediatR;


namespace LibrarySystem.Application.Commands.LoanReturned;

public class LoanReturnedCommand : IRequest<Unit>
{
    public LoanReturnedCommand(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}
