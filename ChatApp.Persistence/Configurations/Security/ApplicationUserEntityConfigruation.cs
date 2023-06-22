using ChatApp.Domain.AuthModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace ChatApp.Persistence.Configurations.Security {

    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {




        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {

            var admin = new ApplicationUser
            {
                Id = "6f09dad5-2268-4410-b755-cf7859927e5f",
                UserName = "Admin",
                NormalizedUserName = "Admin".ToUpperInvariant(),
                Email = "temp@gmail.com",
                NormalizedEmail = "temp@gmail.com".ToUpperInvariant(),
                FullName = "Admin",
                PhoneNumber = "+251921906070",

            };

            admin.PasswordHash = HashUserPassword(admin, "Admin@123");
            builder.HasData(admin);
        }

        private static string HashUserPassword(ApplicationUser user, string password)
        {
            var passHash = new PasswordHasher<ApplicationUser>();
            return passHash.HashPassword(user, password);
        }
    }
}