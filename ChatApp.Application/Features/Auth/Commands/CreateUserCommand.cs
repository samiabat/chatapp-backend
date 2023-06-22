
using ChatApp.Application.Common.Dtos.Security;
using ChatApp.Application.Responses;
using MediatR;

namespace ChatApp.Application.Features.Auth.Commands
{
    public sealed record CreateUserCommand() : IRequest<BaseResponse<UserDto>>
    {
        public UserCreationDto UserCreationDto { get; set; }
    }
}