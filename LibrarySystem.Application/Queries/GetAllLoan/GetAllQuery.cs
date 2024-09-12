using LibrarySystem.Application.ViewModels;
using LibrarySystem.Core.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Application.Queries.GetAllLoan;

public class GetAllQuery : IRequest<List<LoanViewModel>>
{
    public int UserId { get; set; }
    public int BookId { get; set; }
    public LoanStatusEnum Status { get; set; }
}
