
using ChatApp.Application.Common.Dtos.Security;
using ChatApp.Application.Contracts.Identity;
using ChatApp.Application.Features.Auth.Commands;
using ChatApp.Application.Responses;
using MediatR;

namespace ChatApp.Application.Features.Auth.Handlers
{

    public sealed class LoginCommandHandler : IRequestHandler<LoginCommand, BaseResponse<LoginResponse>>
    {
        private readonly IUserRepository _userRepository;

        public LoginCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<BaseResponse<LoginResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {

            var result = await _userRepository.LoginAsync(request.LoginRequest.PhoneNumber);

            var response = new BaseResponse<LoginResponse>();
            response.Success = true;
            response.Message = "Logged In Successfully";
            response.Value = result;
            return response;
        }
    }
}