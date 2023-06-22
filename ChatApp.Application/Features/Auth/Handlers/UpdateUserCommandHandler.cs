
using AutoMapper;
using ChatApp.Application.Common.Dtos.Security;
using ChatApp.Application.Contracts.Identity;
using ChatApp.Application.Contracts.Services;
using ChatApp.Application.Features.Auth.Commands;
using ChatApp.Application.Responses;
using ChatApp.Domain.AuthModel;
using MediatR;

namespace ChatApp.Application.Features.Auth.Handlers
{

    public sealed class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, BaseResponse<UserDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IResourceManager _resourceManager;

        public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper, IResourceManager resourceManager)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _resourceManager = resourceManager;
        }

        public async Task<BaseResponse<UserDto>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {

            var response = new BaseResponse<UserDto>();
            var applicationUser = _mapper.Map<ApplicationUser>(request.User);
            if (request.User.Profilepicture != null)
            {
                Console.WriteLine(request.User.Profilepicture);
                applicationUser.ProfilePicture = (await _resourceManager.UploadImage(request.User.Profilepicture)).AbsoluteUri;
            }


            var updatedUser = await _userRepository.UpdateUserAsync(request.UserId, applicationUser);





            var userDto = _mapper.Map<UserDto>(updatedUser);

            response.Success = true;
            response.Message = "User Updated Successfully";
            response.Value = userDto;
            return response;

        }
    }
}