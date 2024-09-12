using LibrarySystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Core.Repositories;

public interface ILoanRepository
{
    Task<int> Create(Loan loan);
    Task <List<Loan>> GetAllAsync();
    Task<Loan> GetByIdAsync(int id);
    Task Update(int id, Loan loan);
    Task Active(int id);
    Task Cancelled(int id);
    Task Late(int id);
    Task Reserved(int id);
    Task Returned(int id);
    Task Delete(int id);
}
