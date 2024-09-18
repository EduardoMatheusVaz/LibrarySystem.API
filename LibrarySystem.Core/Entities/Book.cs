using LibrarySystem.Core.Enums;
using System.Linq.Expressions;

namespace LibrarySystem.Core.Entities;

public class Book : BaseEntity
{
    public Book(string title, string author, string iSBN, int year, string synopsis)
    {
        Title = title;
        Author = author;
        ISBN = iSBN;
        Year = year;
        Synopsis = synopsis;

        Status = BookStatusEnum.Available;
    }

    // CONSTRUTOR PADRÃO
    public Book()
    {

    }

    public string Title { get; private set; }
    public string Author { get; private set; }
    public string ISBN { get; private set; }
    public int Year  { get; private set; }
    public string Synopsis { get; private set; }
    public BookStatusEnum Status { get; private set; }


    // FOREIGN KEYS
    public int? UserId { get; private set; }
    public int? LoanId { get; private set; }
    

    // NAVIGATION PROPERTIES
    public User Client{ get; private set; }
    public Loan Loans { get; private set; }


    // PASSAGEM DE STATUS & MÉTODOS
    public void Available()
    {
        Status = BookStatusEnum.Available;
    }

    public void Rented()
    {
        if (Status == BookStatusEnum.Available)
        {
            Status = BookStatusEnum.Rented;
        }
    }

    public void Reserved()
    {
        if (Status == BookStatusEnum.Available)
        {
            Status = BookStatusEnum.Reserved;
        }   
    }

    public void Late()
    {
        if(Status == BookStatusEnum.Rented)
        {
            Status = BookStatusEnum.Late;
        }
    }

    public void Off()
    {
        if (Status == BookStatusEnum.Available)
        {
            Status = BookStatusEnum.Off;
        }
        if (Status == BookStatusEnum.Rented)
        {
            Status = BookStatusEnum.Off;
        }
    }

    public void Update(string title, string author, string iSBN, int year, string synopsis)
    {
        Title = title;
        Author = author;
        ISBN = iSBN;
        Year = year;
        Synopsis = synopsis;    
    }
}
