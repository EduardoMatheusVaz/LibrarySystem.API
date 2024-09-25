using LibrarySystem.Core.Entities;
using LibrarySystem.Core.Enums;

namespace LibrarySystem.Application.ViewModels;

public class BookParticularityViewModel : BaseEntity
{
    public BookParticularityViewModel(int id, string title, string author, string iSBN, int year, string synopsis, string gender, BookStatusEnum status)
    {
        Id = id;
        Title = title;
        Author = author;
        ISBN = iSBN;
        Year = year;
        Synopsis = synopsis;
        Status = status;
    }

    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }
    public int Year { get; set; }
    public string Synopsis { get; set; }
    public string Gender { get; set; }
    public BookStatusEnum Status { get; set; }
}
