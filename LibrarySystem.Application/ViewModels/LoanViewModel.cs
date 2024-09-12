using LibrarySystem.Core.Entities;
using LibrarySystem.Core.Enums;

namespace LibrarySystem.Application.ViewModels;

public class LoanViewModel : BaseEntity
{
    public LoanViewModel(int id, int userId, int bookId, LoanStatusEnum status)
    {
        Id = id;
        UserId = userId;
        BookId = bookId;
        Status = status;
    }

    public int Id { get; set; }
    public int UserId { get;  set; }
    public int BookId { get;  set; }
    public LoanStatusEnum Status { get;  set; }
}
