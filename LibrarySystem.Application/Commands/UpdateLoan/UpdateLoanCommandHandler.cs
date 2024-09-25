using LibrarySystem.Core.Entities;
using LibrarySystem.Core.Repositories;
using MediatR;


namespace LibrarySystem.Application.Commands.UpdateLoan;

public class UpdateLoanCommandHandler : IRequestHandler<UpdateLoanCommand, Unit>
{
    private readonly ILoanRepository _loanRepository;

    public UpdateLoanCommandHandler(ILoanRepository loanRepository)
    {
        _loanRepository = loanRepository;
    }

    public async Task<Unit> Handle(UpdateLoanCommand request, CancellationToken cancellationToken)
    {
        var loan = new Loan(request.UserId, request.BookId);

        await _loanRepository.Update(request.Id, loan);

        return Unit.Value;
    }
}
