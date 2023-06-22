using Microsoft.AspNetCore.Identity;

namespace ChatApp.Domain.AuthModel
{
    public class ApplicationUser : IdentityUser
    {

        public int Age { get; set; }
        public string FullName { get; set; } = string.Empty;

        public string? ProfilePicture { get; set; } = string.Empty;

        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }

    }
}
