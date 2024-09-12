using LibrarySystem.Core.Entities;

namespace LibrarySystem.Core.Repositories;

public interface IBookRepository
{
    Task <int> Create(Book book);
    Task<List<Book>> GetAllAsync();
    Task<Book> GetByIdAsync(int id);
    Task Delete(int id);
    Task Update(int id, Book book);
    Task Rented(int id);
    Task Available(int id);
    Task Late(int id);
    Task Reserved(int id);
    
}
