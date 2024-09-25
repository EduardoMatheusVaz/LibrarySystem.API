using LibrarySystem.Core.Repositories;
using LibrarySystem.Infrastructure.Persistence;
using MediatR;


namespace LibrarySystem.Application.Commands.LoanActive;

public class LoanActiveCommandHandler : IRequestHandler<LoanActiveCommand, Unit>
{
    private readonly ILoanRepository _loanRepository;
    private readonly LibrarySystemDbContext _dbcontext;

    public LoanActiveCommandHandler(ILoanRepository loanRepository, LibrarySystemDbContext dbcontext)
    {
        _loanRepository = loanRepository;
        _dbcontext = dbcontext;
    }

    public async Task<Unit> Handle(LoanActiveCommand request, CancellationToken cancellationToken)
    {
        await _loanRepository.Active(request.Id);

        return Unit.Value;
    }
}
