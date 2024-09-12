using LibrarySystem.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Core.Entities;

public class Loan : BaseEntity
{
    public Loan(int userId, int bookId)
    {
        UserId = userId;
        BookId = bookId;
        

        Date = DateTime.Now;
        Status = LoanStatusEnum.Active;
    }

    public Loan()
    {
        
    }

    public DateTime Date { get; private set; }
    public LoanStatusEnum Status { get; private set; }


    // FOREIGN KEYS
    public int UserId { get; private set; }
    public int BookId { get; private set; }


    // NAVIGATION PROPERTIES
    public User Client { get; private set; }
    public Book Books { get; private set; }


    // PASSAGEM DE STATUS
    public void Update(int userId, int bookId, DateTime date, LoanStatusEnum status)
    {
        UserId = userId;
        BookId = bookId;
        Date = date;
        Status = status;
    }

    public void Active()
    {
        if(Date == DateTime.Now)
        {
            Status = LoanStatusEnum.Active;
        }
    }

    public void Returned()
    {
        if (Status == LoanStatusEnum.Active || Status == LoanStatusEnum.Late)
        {
            Status = LoanStatusEnum.Returned;
        }
    }

    public void Late()
    {
        if(Status == LoanStatusEnum.Active)
        {
            Status = LoanStatusEnum.Late;
        }
    }

    public void Reserved()
    {
        if (Status == LoanStatusEnum.Active)
        {
            Status = LoanStatusEnum.Reserved;
        }
    }

    public void Cancelled()
    {
        if(Status == LoanStatusEnum.Active || Status == LoanStatusEnum.Reserved)
        {
            Status = LoanStatusEnum.Cancelled;
        }
    }

}