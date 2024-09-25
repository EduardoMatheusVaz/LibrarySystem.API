using MediatR;


namespace LibrarySystem.Application.Commands.LoanLate;

public class LoanLateCommand : IRequest<Unit>
{
    public LoanLateCommand(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}
