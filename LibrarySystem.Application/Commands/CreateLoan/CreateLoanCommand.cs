﻿using LibrarySystem.Core.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Application.Commands.CreateLoan;

public class CreateLoanCommand : IRequest<int>
{
    public CreateLoanCommand(int userId, int bookId)
    {
        UserId = userId;
        BookId = bookId;

        Date = DateTime.Now;
        Status = LoanStatusEnum.Active;
    }

    public int UserId { get; set; }
    public int BookId { get; set; }
    public DateTime Date { get; private set; }
    public LoanStatusEnum Status { get; private set; }
}
