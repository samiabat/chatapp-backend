
using ChatApp.Application.Common.Dtos.Security;
using ChatApp.Application.Responses;
using MediatR;
namespace ChatApp.Application.Features.Auth.Commands
{
    public sealed record CreateAdminUserCommand() : IRequest<BaseResponse<AdminUserDto>>
    {
        public AdminCreationDto AdminCreationDto { get; set; }
    }
}