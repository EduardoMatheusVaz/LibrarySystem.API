using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Application.Commands.BookRented;

public class BookRentedCommand : IRequest<Unit>
{
    public BookRentedCommand(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}
