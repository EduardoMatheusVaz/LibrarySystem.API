 using Azure.Core;
using Dapper;
using LibrarySystem.Core.Entities;
using LibrarySystem.Core.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Infrastructure.Persistence.Repositories;

public class LoanRepository : ILoanRepository
{
    private readonly string _connectionString;
    private readonly LibrarySystemDbContext _dbcontext;

    public LoanRepository(IConfiguration configuration, LibrarySystemDbContext dbcontext)
    {
        _connectionString = configuration.GetConnectionString("DataBase");
        _dbcontext = dbcontext;
    }

    public async Task Active(int id)
    {
        var loan = _dbcontext.Loan.SingleOrDefault(p => p.Id == id);

        loan.Active();

        await _dbcontext.SaveChangesAsync();
    }

    public async Task<int> Create(Loan loan)
    {
        var newLoan = new Loan(loan.UserId, loan.BookId);
        await _dbcontext.Loan.AddAsync(newLoan);
        await _dbcontext.SaveChangesAsync();

        return loan.Id;
    }

    public async Task Delete(int id)
    {

        var loan = _dbcontext.Loan.SingleOrDefault(l => l.Id == id);

        loan.Cancelled();

        await _dbcontext.SaveChangesAsync();

    }

    public async Task<List<Loan>> GetAllAsync()
    {
        using (var sqlConnection = new SqlConnection(_connectionString))
        {
            sqlConnection.Open();

            var script = "SELECT * FROM tb_Loan";

            var loan = await sqlConnection.QueryAsync<Loan>(script);

            return loan.ToList();
        }
    }

    public async Task<Loan> GetByIdAsync(int id)
    {
        using (var sqlConnection = new SqlConnection(_connectionString))
        {
            sqlConnection.Open();

            var script = "SELECT Id, UserId, BookId, Date, Status FROM tb_Loan WHERE Id = @Id";

            var loan = await sqlConnection.QueryFirstOrDefaultAsync<Loan>(script, new { Id = id });

            return loan;
        }
    }

    public async Task Late(int id)
    {
        var loan = _dbcontext.Loan.SingleOrDefault(p => p.Id == id);

        loan.Late();

        await _dbcontext.SaveChangesAsync();
    }

    public async Task Reserved(int id)
    {
        var loan = _dbcontext.Loan.SingleOrDefault(p => p.Id == id);

        loan.Reserved();

        await _dbcontext.SaveChangesAsync();
    }

    public async Task Returned(int id)
    {
        var loan = _dbcontext.Loan.SingleOrDefault(p => p.Id == id);

        loan.Returned();

        await _dbcontext.SaveChangesAsync();
    }
    public async Task Update(int id, Loan loan)
    {
        using (var sqlConnection = new SqlConnection(_connectionString))
        {
            sqlConnection.Open();

            var script = "UPDATE tb_Loan SET Status = @Status, UserId = @UserId, BookId = @BookId WHERE Id = @Id";

            await sqlConnection.ExecuteAsync(script, new { Id = loan.Id, Status = loan.Status, UserId = loan.UserId, BookId = loan.BookId });
        }
    }
}
