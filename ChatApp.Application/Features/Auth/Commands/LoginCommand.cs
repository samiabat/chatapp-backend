
using ChatApp.Application.Common.Dtos.Security;
using ChatApp.Application.Responses;
using MediatR;
namespace ChatApp.Application.Features.Auth.Commands
{
    public sealed record LoginCommand() : IRequest<BaseResponse<LoginResponse>>
    {
        public LoginRequest LoginRequest { get; set; }
    }
}
