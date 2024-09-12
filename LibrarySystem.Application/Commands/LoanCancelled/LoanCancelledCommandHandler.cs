using LibrarySystem.Core.Repositories;
using LibrarySystem.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Application.Commands.LoanCancelled;

public class LoanCancelledCommandHandler : IRequestHandler<LoanCancelledCommand, Unit>
{
    private readonly LibrarySystemDbContext _dbcontext;
    private readonly ILoanRepository _loanRepository;

    public LoanCancelledCommandHandler(LibrarySystemDbContext dbcontext, ILoanRepository loanRepository)
    {
        _dbcontext = dbcontext;
        _loanRepository = loanRepository;
    }
    public async Task<Unit> Handle(LoanCancelledCommand request, CancellationToken cancellationToken)
    {
        await _loanRepository.Cancelled(request.Id);

        return Unit.Value;
    }
}
