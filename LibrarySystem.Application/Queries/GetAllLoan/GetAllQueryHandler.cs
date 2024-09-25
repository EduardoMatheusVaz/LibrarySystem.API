using LibrarySystem.Application.ViewModels;
using LibrarySystem.Core.Repositories;
using MediatR;


namespace LibrarySystem.Application.Queries.GetAllLoan;

public class GetAllQueryHandler : IRequestHandler<GetAllQuery, List<LoanViewModel>>
{
    private readonly ILoanRepository _loanRepository;

    public GetAllQueryHandler(ILoanRepository loanRepository)
    {
        _loanRepository = loanRepository;
    }

    public async Task<List<LoanViewModel>> Handle(GetAllQuery request, CancellationToken cancellationToken)
    {
        var loan = await _loanRepository.GetAllAsync();

        var loans = loan.Select(x => new LoanViewModel(
            x.Id,
            x.UserId,
            x.BookId,
            x.Status
            )).ToList();

        return loans;
    }
}
