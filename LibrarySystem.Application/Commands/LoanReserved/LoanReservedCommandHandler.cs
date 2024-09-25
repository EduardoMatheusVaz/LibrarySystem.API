using LibrarySystem.Core.Repositories;
using MediatR;


namespace LibrarySystem.Application.Commands.LoanReserved;

public class LoanReservedCommandHandler : IRequestHandler<LoanReservedCommand, Unit>
{
    private readonly ILoanRepository _loanRepository;

    public LoanReservedCommandHandler(ILoanRepository loanRepository)
    {
        _loanRepository = loanRepository;
    }

    public async Task<Unit> Handle(LoanReservedCommand request, CancellationToken cancellationToken)
    {
        await _loanRepository.Reserved(request.Id);

        return Unit.Value;
    }
}
