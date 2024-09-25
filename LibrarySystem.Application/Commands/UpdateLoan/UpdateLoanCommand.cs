using LibrarySystem.Core.Enums;
using MediatR;


namespace LibrarySystem.Application.Commands.UpdateLoan;

public class UpdateLoanCommand : IRequest<Unit>
{
    public UpdateLoanCommand(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
    public int UserId { get; set; }
    public int BookId { get; set; }
    public DateTime? Date { get; set; }
    public LoanStatusEnum? Status { get; set; }
}
