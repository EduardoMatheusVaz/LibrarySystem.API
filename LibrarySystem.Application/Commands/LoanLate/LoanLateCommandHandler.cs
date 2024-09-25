using LibrarySystem.Core.Repositories;
using MediatR;


namespace LibrarySystem.Application.Commands.LoanLate;

public class LoanLateCommandHandler : IRequestHandler<LoanLateCommand, Unit>
{
    private readonly ILoanRepository _loanRepository;

    public LoanLateCommandHandler(ILoanRepository loanRepository)
    {
        _loanRepository = loanRepository;
    }

    public async Task<Unit> Handle(LoanLateCommand request, CancellationToken cancellationToken)
    {
        await _loanRepository.Late(request.Id);

        return Unit.Value;
    }
}
