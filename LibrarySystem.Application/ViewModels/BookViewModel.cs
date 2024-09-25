using LibrarySystem.Core.Entities;
using LibrarySystem.Core.Enums;
using System.Text.Json.Serialization;

namespace LibrarySystem.Application.ViewModels;

public class BookViewModel : BaseEntity
{
    public BookViewModel(int id, string title, string author, string iSBN, int year, string synopsis, string gender)
    {
        Id = id;
        Title = title;
        Author = author;
        ISBN = iSBN;
        Year = year;
        Synopsis = synopsis;
        Gender = gender;
    }

    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }
    public int Year { get; set; }
    public string Synopsis { get; set; }
    public string Gender { get; set; }
}
