using LibrarySystem.Core.Enums;
using MediatR;


namespace LibrarySystem.Application.Commands.CreateLoan;

public class CreateLoanCommand : IRequest<int>
{
    public CreateLoanCommand(int userId, int bookId)
    {
        UserId = userId;
        BookId = bookId;

        Date = DateTime.Now;
        Status = LoanStatusEnum.Active;
    }

    public int UserId { get; set; }
    public int BookId { get; set; }
    public DateTime Date { get; private set; }
    public LoanStatusEnum Status { get; private set; }
}
