using LibrarySystem.Core.Entities;
using LibrarySystem.Core.Enums;

namespace LibrarySystem.Application.ViewModels;

public class LoanParticularityViewModel : BaseEntity
{
    public LoanParticularityViewModel(int id, int bookId, int userId, DateTime date, LoanStatusEnum status)
    {
        Id = id;
        BookId = bookId;
        UserId = userId;
        Date = date;
        Status = status;
    }

    public int Id { get; set; }
    public int BookId { get; set; }
    public int UserId { get; set; }
    public DateTime Date { get; set; }
    public LoanStatusEnum Status { get; set; }
}
