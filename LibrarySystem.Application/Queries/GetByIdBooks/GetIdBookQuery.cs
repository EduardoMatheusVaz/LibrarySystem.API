using LibrarySystem.Application.ViewModels;
using LibrarySystem.Core.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Application.Queries.GetByIdBooks;
public class GetIdBookQuery : IRequest<BookParticularityViewModel>
{
    public GetIdBookQuery(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}
