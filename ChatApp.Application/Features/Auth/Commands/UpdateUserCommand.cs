

using ChatApp.Application.Common.Dtos.Security;
using ChatApp.Application.Responses;
using MediatR;

namespace ChatApp.Application.Features.Auth.Commands
{
    public sealed record UpdateUserCommand() : IRequest<BaseResponse<UserDto>>

    {
        public string UserId { get; set; }
        public UserUpdatingDto User { get; set; }
    }
}