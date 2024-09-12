using LibrarySystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace LibrarySystem.Infrastructure.Persistence.Configurations;
public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<LibrarySystemDbContext>
{
    public LibrarySystemDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<LibrarySystemDbContext>();
        optionsBuilder.UseSqlServer("Server=LAPTOP-BPQKIBEO\\SQLSERVER2022;Database=DB_LibrarySystem;User Id=sa;Password=Mortadela1!;TrustServerCertificate=True");

        return new LibrarySystemDbContext(optionsBuilder.Options);
    }
}