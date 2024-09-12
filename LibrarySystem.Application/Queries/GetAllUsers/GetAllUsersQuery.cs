using LibrarySystem.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Application.Queries.GetAllUsers;

public class GetAllUsersQuery : IRequest<List<UserViewModel>>
{
    public string Name { get; set; }
    public string Email { get; set; }
    public int Phone { get; set; }
}
