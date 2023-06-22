using ChatApp.Application.Common.Dtos.Security;
using ChatApp.Application.Responses;
using MediatR;
namespace ChatApp.Application.Features.Auth.Queries

{
	public class GetAllUsersQuery : IRequest<BaseResponse<List<UserDto>>>
	{
	
    }
}