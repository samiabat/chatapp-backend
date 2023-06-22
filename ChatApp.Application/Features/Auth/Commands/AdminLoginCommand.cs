
using ChatApp.Application.Common.Dtos.Security;
using ChatApp.Application.Responses;
using MediatR;


namespace ChatApp.Application.Features.Auth.Commands
{

    public sealed record AdminLoginCommand() : IRequest<BaseResponse<LoginResponse>>
    {
        public LoginRequestByAdmin LoginRequest { get; set; }
    }
}
