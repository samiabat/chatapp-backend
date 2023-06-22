using ChatApp.Application.Common.Dtos.Security;
using ChatApp.Application.Responses;
using MediatR;
namespace ChatApp.Application.Features.Auth.Commands
{
    public sealed record UpdateAdminUserCommand() : IRequest<BaseResponse<AdminUserDto>>

    {
        public string UserId { get; set; }
        public AdminUpdatingDto UpdatingDto { get; set; }
    }
}