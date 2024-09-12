using LibrarySystem.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace LibrarySystem.Infrastructure.Persistence.Configurations
{
    public class BookConfigurations : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {

            builder
                .ToTable("tb_Book")
                .HasKey(b => b.Id);


            builder
                .HasOne(u => u.Client)
                .WithMany(b => b.Books)
                .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.Restrict);


            builder
                .HasOne(u => u.Loans)
                .WithOne(b => b.Books)
                .HasForeignKey<Book>(f => f.LoanId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
