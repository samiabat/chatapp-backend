using System.Net;
using ChatApp.Application.Common.Dtos.Security;
using ChatApp.Application.Features.Auth.Commands;
using ChatApp.Application.Features.Auth.Queries;
using ChatApp.Application.Responses;
using ChatApp.WebApi.Controllers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChatApp.WebApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UserController : BaseApiController
    {
        public UserController(IMediator mediator) : base(mediator)
        {
        }
        /*
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {


            var result = await _mediator.Send(new LoginCommand { LoginRequest = loginRequest });

            var status = result.Success ? HttpStatusCode.OK : HttpStatusCode.NotFound;
            return getResponse<BaseResponse<LoginResponse>>(status, result);
        }
        */

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginAdmin(LoginRequestByAdmin loginRequest)
        {


            var result = await _mediator.Send(new AdminLoginCommand { LoginRequest = loginRequest });

            var status = result.Success ? HttpStatusCode.OK : HttpStatusCode.NotFound;
            return getResponse<BaseResponse<LoginResponse>>(status, result);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromForm] UserCreationDto userCreationDto)
        {
            var result = await _mediator.Send(new CreateUserCommand { UserCreationDto = userCreationDto });

            var status = result.Success ? HttpStatusCode.Created : HttpStatusCode.BadRequest;
            return getResponse<BaseResponse<UserDto>>(status, result);
        }

        [HttpPost("admin")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateUser([FromBody] AdminCreationDto userCreationDto)
        {
            var result = await _mediator.Send(new CreateAdminUserCommand { AdminCreationDto = userCreationDto });

            var status = result.Success ? HttpStatusCode.Created : HttpStatusCode.BadRequest;
            return getResponse<BaseResponse<AdminUserDto>>(status, result);
        }



        [HttpPut("{id}")]

        public async Task<IActionResult> Update(string id, [FromForm] UserUpdatingDto userUpdatingDto)
        {
            var result = await _mediator.Send(new UpdateUserCommand { UserId = id, User = userUpdatingDto });

            var status = result.Success ? HttpStatusCode.Created : HttpStatusCode.BadRequest;
            return getResponse<BaseResponse<UserDto>>(status, result);
        }

        [HttpPut("admin/{id}")]

        public async Task<IActionResult> UpdateAdmin(string id, [FromBody] AdminUpdatingDto userUpdatingDto)
        {
            var result = await _mediator.Send(new UpdateAdminUserCommand { UserId = id, UpdatingDto = userUpdatingDto });

            var status = result.Success ? HttpStatusCode.Created : HttpStatusCode.BadRequest;
            return getResponse<BaseResponse<AdminUserDto>>(status, result);
        }

        [HttpGet("users/all")]

        public async Task<IActionResult> GetAllUser()
        {


            var result = await _mediator.Send(new GetAllUsersQuery { });

            var status = result.Success ? HttpStatusCode.OK : HttpStatusCode.NotFound;
            return getResponse(status, result);
        }

        [HttpGet("roles/all")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllRoles()
        {


            var result = await _mediator.Send(new GetAllRolesQuery { });

            var status = result.Success ? HttpStatusCode.OK : HttpStatusCode.NotFound;
            return getResponse(status, result);
        }
    }
}

