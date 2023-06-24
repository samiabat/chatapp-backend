namespace ChatApp.Application.Common.Dtos.Security
{
    public sealed record LoginResponse(string Message, string? AccessToken,
    string? refreshToken, string Id, string userName, string fullName, string email, string profilePic);
}