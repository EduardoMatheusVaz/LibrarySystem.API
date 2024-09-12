using LibrarySystem.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Core.Entities;

public class User : BaseEntity
{
    public User(string name, string email, int phone)
    {
        Name = name;
        Email =     email;
        Phone = phone;
        
        Status = UserEnum.Active;
        Registered = DateTime.Now;
    }

    public User()
    {
        
    }

    public string Name { get; private set; }
    public string Email { get; private set; }
    public int Phone { get; private set; }
    public UserEnum Status { get; private set; }
    public DateTime Registered { get; private set; } 


    // FOREIGN KEYS
    public int? BookId { get; private set; }
    public int? LoanId { get; private set; }


    // NAVIGATION PROPERTIES
    public ICollection<Book> Books { get; private set; }
    public ICollection<Loan> Loans { get; private set; }


    // PASSAGEM DE STATUS E MÉTODOS

    public void Active()
    {
        if(Registered == DateTime.Now || Status == UserEnum.Off)
        {
            Status = UserEnum.Active;
        }
    }

    public void Off()
    {
        if(Status == UserEnum.Active)
        {
            Status = UserEnum.Off;
        }
    }

    public void Update(string name, string emai, int Phone)
    {
        Name = name;
        Email = emai;
        Phone = Phone;
    }

}
