using CleanArchitecture.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Identity.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            builder.HasData(
                new ApplicationUser
                {
                    Id = "USER1",
                    Email = "admin@gmail.com",
                    NormalizedEmail = "admin@gmail.com",
                    Nombre = "chaleco",
                    Apellidos = "lopez",
                    UserName = "chalecolopez",
                    NormalizedUserName = "chalecolopez",
                    PasswordHash = hasher.HashPassword(null, "1234"),
                    EmailConfirmed = true
                },
                new ApplicationUser
                {
                    Id = "USER2",
                    Email = "normal@gmail.com",
                    NormalizedEmail = "normal@gmail.com",
                    Nombre = "normal",
                    Apellidos = "normal",
                    UserName = "normal",
                    NormalizedUserName = "normal",
                    PasswordHash = hasher.HashPassword(null, "1234"),
                    EmailConfirmed = true
                }
           );
        }
    }
}
