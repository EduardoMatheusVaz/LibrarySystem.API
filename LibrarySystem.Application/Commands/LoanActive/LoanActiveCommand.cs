using MediatR;


namespace LibrarySystem.Application.Commands.LoanActive;

public class LoanActiveCommand : IRequest<Unit>
{
    public LoanActiveCommand(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}
