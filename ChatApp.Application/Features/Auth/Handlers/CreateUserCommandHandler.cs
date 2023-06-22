
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

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, BaseResponse<UserDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly ISmsSender _smsSender;
        private readonly IMapper _mapper;
        private readonly IResourceManager _resourceManager;
        private static Random random = new Random();

        public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper, IResourceManager resourceManager)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _resourceManager = resourceManager;

        }

        public async Task<BaseResponse<UserDto>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {

            var roles = request.UserCreationDto.Roles;
            var applicationRoles = _mapper.Map<List<ApplicationRole>>(roles);


            var applicationUser = _mapper.Map<ApplicationUser>(request.UserCreationDto);
            if (request.UserCreationDto.Profilepicture != null)
            {
                applicationUser.ProfilePicture = (await _resourceManager.UploadImage(request.UserCreationDto.Profilepicture)).AbsoluteUri;
            }

            var user = await _userRepository.CreateUserAsync(applicationUser, applicationRoles);

            var userDto = _mapper.Map<UserDto>(user);





            var response = new BaseResponse<UserDto>();
            response.Success = true;
            response.Message = "User Created Successfully";
            response.Value = userDto;
            return response;
        }
    }
}