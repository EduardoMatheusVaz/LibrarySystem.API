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

public class BookRepository : IBookRepository
{
    private readonly string _connectionstring;
    private readonly LibrarySystemDbContext _dbcontext;
    public BookRepository(IConfiguration configuration, LibrarySystemDbContext  librarySystemDbContext)
    {
        _connectionstring = configuration.GetConnectionString("DataBase");
        _dbcontext = librarySystemDbContext;
    }

    public async Task Available(int id)
    {
        var book = _dbcontext.Book.SingleOrDefault(x => x.Id == id);
        
        book.Available();

        await _dbcontext.SaveChangesAsync();
    }

    public async Task<int> Create(Book book)
    {
        var newBook = new Book(book.Title, book.Author, book.ISBN, book.Year, book.Synopsis);
        await _dbcontext.Book.AddAsync(newBook);
        await _dbcontext.SaveChangesAsync();

        return book.Id;
    }

    public async Task Delete(int id)
    {

        var book = _dbcontext.Book.SingleOrDefault(b => b.Id == id);

        book.Off();

        await _dbcontext.SaveChangesAsync();
    }

    public async Task<List<Book>> GetAllAsync()
    {
        using (var sqlConnection = new SqlConnection(_connectionstring))
        {
            sqlConnection.Open();

            var script = "SELECT Id, Title, Author, ISBN, Year, Synopsis FROM tb_Book";

            var books = await sqlConnection.QueryAsync<Book>(script);

            return books.ToList();
        }
    }

    public async Task<Book> GetByIdAsync(int id)
    {
        using (var sqlConnection = new SqlConnection(_connectionstring))
        {
            sqlConnection.Open();

            var script = "SELECT Id, Title, Author, ISBN, Year, Synopsis, Status FROM tb_Book WHERE Id = @Id";

            var book = await sqlConnection.QueryFirstAsync<Book>(script, new { Id = id });

            return book;
        }
    }

    public async Task Late(int id)
    {
        var book = _dbcontext.Book.SingleOrDefault(p => p.Id == id);

        book.Late();

        await _dbcontext.SaveChangesAsync();
    }

    public async Task Rented(int id)
    {
        var book = _dbcontext.Book.SingleOrDefault(p => p.Id == id);

        book.Rented();

        await _dbcontext.SaveChangesAsync();
    }

    public async Task Reserved(int id)
    {
        var book = _dbcontext.Book.SingleOrDefault(p => p.Id == id);

        book.Reserved();

        await _dbcontext.SaveChangesAsync();
    }

    public async Task Update(int id, Book book)
    {
        using (var sqlConnection = new SqlConnection(_connectionstring))
        {
            sqlConnection.Open();

            var script = "UPDATE tb_Book SET Title = @Title, Author = @Author, ISBN = @ISBN, Year = @Year, Synopsis = @Synopsis WHERE Id = @Id";

            var bookUpdate = await sqlConnection.ExecuteAsync(script, new { Title = book.Title, Author = book.Author, ISBN = book.ISBN, Year = book.Year, Synopsis = book.Synopsis });
        }
    }
}
