
using AutoMapper;
using ChatApp.Application.Common.Dtos.Security;
using ChatApp.Application.Contracts.Identity;
using ChatApp.Application.Features.Auth.Commands;
using ChatApp.Application.Responses;
using ChatApp.Domain.AuthModel;
using MediatR;


namespace ChatApp.Application.Features.Auth.Handlers
{
    public sealed class UpdateAdminUserCommandHandler : IRequestHandler<UpdateAdminUserCommand, BaseResponse<AdminUserDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UpdateAdminUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<AdminUserDto>> Handle(UpdateAdminUserCommand request, CancellationToken cancellationToken)
        {

            var response = new BaseResponse<AdminUserDto>();
            var applicationUser = _mapper.Map<ApplicationUser>(request.UserId);


            var updatedUser = await _userRepository.UpdateUserAsync(request.UserId, applicationUser);

            var userDto = _mapper.Map<AdminUserDto>(updatedUser);

            response.Success = true;
            response.Message = "User Updated Successfully";
            response.Value = userDto;
            return response;
        }
    }
}