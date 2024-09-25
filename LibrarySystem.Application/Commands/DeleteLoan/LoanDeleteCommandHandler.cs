using LibrarySystem.Core.Repositories;
using MediatR;


namespace LibrarySystem.Application.Commands.DeleteLoan;

public class LoanDeleteCommandHandler : IRequestHandler<LoanDeleteCommand, Unit>
{
    private readonly ILoanRepository _loanRepository;

    public LoanDeleteCommandHandler(ILoanRepository loanRepository)
    {
        _loanRepository = loanRepository;
    }

    public async Task<Unit> Handle(LoanDeleteCommand request, CancellationToken cancellationToken)
    {
        await _loanRepository.Delete(request.Id);
        
        return Unit.Value;
    }
}
