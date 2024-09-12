using LibrarySystem.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Application.Queries.GetByIdUsers;

public class GetIdUserQuery : IRequest<UserParticularityViewModel>
{
    public GetIdUserQuery(int id)
    {
        Id = id;

    }

    public int Id { get; set; }
}
