using LibrarySystem.Core.Repositories;
using MediatR;


namespace LibrarySystem.Application.Commands.LoanReturned;

public class LoanReturnedCommandHandler : IRequestHandler<LoanReturnedCommand, Unit>
{
    private readonly ILoanRepository _loanRepository;

    public LoanReturnedCommandHandler(ILoanRepository loanRepository)
    {
        _loanRepository = loanRepository;
    }

    public async Task<Unit> Handle(LoanReturnedCommand request, CancellationToken cancellationToken)
    {
        await _loanRepository.Returned(request.Id);

        return Unit.Value;
    }
}
