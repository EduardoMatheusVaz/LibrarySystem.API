using LibrarySystem.Core.Entities;

namespace LibrarySystem.Application.ViewModels;

public class UserViewModel : BaseEntity
{
    public UserViewModel(int id, string name, string email, int phone)
    {
        Id = id;
        Name = name;
        Email = email;
        Phone = phone;
    }

    public int Id { get; set; }
    public string Name { get;  set; }
    public string Email { get;  set; }
    public int Phone { get;  set; }
}
