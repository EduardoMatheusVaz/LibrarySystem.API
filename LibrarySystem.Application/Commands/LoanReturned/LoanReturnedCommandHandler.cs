using LibrarySystem.Core.Repositories;
using LibrarySystem.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
