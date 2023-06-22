
using ChatApp.Application.Common.Dtos.Security;
using ChatApp.Domain.AuthModel;

namespace ChatApp.Application.Contracts.Identity
{

    public interface IJwtService
    {
        Task<TokenDto> GenerateToken(ApplicationUser user);
        Task<TokenDto?> RefreshToken(TokenDto tokenDto);
    }
}