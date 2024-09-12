using LibrarySystem.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Security.Cryptography;

namespace LibrarySystem.Infrastructure.Persistence;

public class LibrarySystemDbContext : DbContext
{
    public LibrarySystemDbContext(DbContextOptions<LibrarySystemDbContext> options) : base(options)
    {

    }

    public DbSet<User> User { get; set; }
    public DbSet<Book> Book { get; set; }
    public DbSet<Loan> Loan { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

}
