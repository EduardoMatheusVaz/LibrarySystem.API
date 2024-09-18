using Azure.Core;
using Dapper;
using LibrarySystem.Core.Entities;
using LibrarySystem.Core.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly LibrarySystemDbContext _dbcontext;
    private readonly string _connectionstring;

    public UserRepository(IConfiguration configuration, LibrarySystemDbContext librarySystem)
    {
        _connectionstring = configuration.GetConnectionString("DataBase");
        _dbcontext = librarySystem;
    }
    public async Task Active(int id)
    {
        var user = _dbcontext.User.SingleOrDefault(p => p.Id == id);

        user.Active();

        await _dbcontext.SaveChangesAsync();
    }

    public async Task<int> Create(User user)
    {
        var userNew = new User(user.Name, user.Email, user.Phone);
        await _dbcontext.User.AddAsync(userNew);
        await _dbcontext.SaveChangesAsync();

        return userNew.Id;
    }

    public async Task Delete(int id)
    {

        var user = _dbcontext.User.SingleOrDefault(u => u.Id == id);

        user.Off();

        await _dbcontext.SaveChangesAsync();

    }

    public async Task<List<User>> GetAllAsync()
    {
        using (var sqlConnection = new SqlConnection(_connectionstring))
        {
            sqlConnection.Open();

            var script = "SELECT * FROM tb_User";

            var users = await sqlConnection.QueryAsync<User>(script);

            return users.ToList();
        }
    }

    public async Task<User> GetByIdAsync(int id)
    {
        using (var sqlConnection = new SqlConnection(_connectionstring))
        {
            sqlConnection.Open();

            var script = "SELECT * FROM tb_User WHERE Id = @Id";

            var user = await sqlConnection.QueryFirstOrDefaultAsync<User>(script, new { Id = id });

            return user;
        }
    }

    public async Task Update(int id, User user)
    {
        using (var sqlConnection = new SqlConnection(_connectionstring))
        {
            sqlConnection.Open();

            var script = "UPDATE tb_User SET Name = @Name, Email = @Email, Phone = @Phone WHERE Id = @Id";

            await sqlConnection.ExecuteAsync(script, new { Name = user.Name, Email = user.Email, Phone = user.Phone, Id = id });
        }
    }
}
