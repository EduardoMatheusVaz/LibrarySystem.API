using Dapper;
using LibrarySystem.Application.ViewModels;
using LibrarySystem.Core.Repositories;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Application.Queries.GetByIdLoan;

public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, LoanParticularityViewModel>
{
    private readonly ILoanRepository _loanRepository;

    public GetByIdQueryHandler(ILoanRepository loanRepository)
    {
        _loanRepository = loanRepository;
    }

    public async Task<LoanParticularityViewModel> Handle(GetByIdQuery request, CancellationToken cancellationToken)
    {
        var loans = await _loanRepository.GetByIdAsync(request.Id);

        var loanssss = new LoanParticularityViewModel(loans.Id, loans.UserId, loans.BookId, loans.Date, loans.Status);

        return loanssss;
    }
}
