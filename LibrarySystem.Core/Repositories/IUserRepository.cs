using LibrarySystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Core.Repositories;

public interface IUserRepository
{

    Task<int> Create(User user);
    Task <List<User>> GetAllAsync();
    Task<User> GetByIdAsync(int id);
    Task Update(int id, User user);
    Task Active(int id);
    Task Off(int id);
    Task Delete(int id);
}
