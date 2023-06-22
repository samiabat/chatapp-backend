
using ChatApp.Application.Common.Dtos.Security;
using ChatApp.Domain.AuthModel;

namespace ChatApp.Application.Contracts.Identity
{
    public interface IUserRepository
    {
        Task<ApplicationUser> FindByEmailAsync(string email);
        Task<ApplicationUser> FindByIdAsync(string userId);
        Task<ApplicationUser> CreateUserAsync(ApplicationUser user, List<ApplicationRole> roles);
        Task<ApplicationUser> CreateAdminUserAsync(ApplicationUser user, string password, List<ApplicationRole> roles);
        Task<bool> CheckPasswordAsync(ApplicationUser user, string password);
        Task<ApplicationUser> UpdateUserAsync(string userId, ApplicationUser user);
        Task<ApplicationUser> UpdateAdminUserAsync(string userId, ApplicationUser user);
        Task<IEnumerable<ApplicationUser>> GetUsersAsync();
        Task DeleteUserAsync(string userId);
        Task<bool> CheckEmailExistence(string email, string? userId);
        Task<ApplicationUser> GetUserById(string userId);
        Task ResetPassword(string userId, string password);
        Task<LoginResponse> LoginAsync(string phoneNumber);
        Task<LoginResponse> LoginByAdminAsync(string userName, string password);
        Task<TokenDto?> RefreshToken(TokenDto tokenDto);

    }

}