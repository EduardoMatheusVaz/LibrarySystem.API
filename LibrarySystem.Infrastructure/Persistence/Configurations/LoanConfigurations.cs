using LibrarySystem.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace LibrarySystem.Infrastructure.Persistence.Configurations
{
    public class LoanConfigurations : IEntityTypeConfiguration<Loan>
    {
        public void Configure(EntityTypeBuilder<Loan> builder)
        {

            builder
                .ToTable("tb_Loan")
            .HasKey(l => l.Id);


            builder
                .HasOne(b => b.Books)
                .WithOne(b => b.Loans)
                .HasForeignKey<Loan>(l => l.BookId)
                .OnDelete(DeleteBehavior.Restrict);


            builder
                .HasOne(u => u.Client)
                .WithMany(l => l.Loans)
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
