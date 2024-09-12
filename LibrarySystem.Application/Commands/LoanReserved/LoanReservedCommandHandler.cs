using LibrarySystem.Core.Repositories;
using LibrarySystem.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
