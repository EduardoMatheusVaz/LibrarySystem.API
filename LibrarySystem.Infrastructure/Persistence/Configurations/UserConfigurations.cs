using LibrarySystem.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace LibrarySystem.Infrastructure.Persistence.Configurations
{
    public class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder
                .ToTable("tb_User")
            .HasKey(u => u.Id);


            builder
                .HasMany(b => b.Books)
                .WithOne(u => u.Client)
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.Restrict);


            builder
                .HasMany(l => l.Loans)
                .WithOne(u => u.Client)
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
