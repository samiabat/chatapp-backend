
using ChatApp.Domain.AuthModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatApp.Persistence.Configurations.Security
{

    public class ApplicationRoleEntityConfiguration : IEntityTypeConfiguration<ApplicationRole>
    {
        private const string AdminRoleId = "bcaa5c92-d9d8-4106-8150-91cb40139030";
        private const string UserRoleId = "5970d313-8ead-434b-a1ea-cacbc6b5c0e9";
        private const string Admin = "Admin";
        private const string User = "User";



        public void Configure(EntityTypeBuilder<ApplicationRole> builder)
        {
            var admin = new ApplicationRole
            {
                Id = AdminRoleId,
                Name = Admin,
                NormalizedName = Admin.ToUpperInvariant()
            };
            builder.HasData(admin);

            var user = new ApplicationRole
            {
                Id = UserRoleId,
                Name = User,
                NormalizedName = User.ToUpperInvariant()
            };
            builder.HasData(user);
        }
    }
}