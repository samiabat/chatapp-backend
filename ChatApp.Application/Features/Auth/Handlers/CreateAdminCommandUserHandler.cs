
using AutoMapper;
using ChatApp.Application.Common.Dtos.Security;
using ChatApp.Application.Contracts.Identity;
using ChatApp.Application.Features.Auth.Commands;
using ChatApp.Application.Responses;
using ChatApp.Domain.AuthModel;
using MediatR;
namespace ChatApp.Application.Features.Auth.Handlers
{

    public class CreateAdminUserCommandHanlder : IRequestHandler<CreateAdminUserCommand, BaseResponse<AdminUserDto>>
    {
        private readonly IUserRepository _userRepository;

        private readonly IMapper _mapper;
        private static Random random = new Random();

        public CreateAdminUserCommandHanlder(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;

        }

        public async Task<BaseResponse<AdminUserDto>> Handle(CreateAdminUserCommand request, CancellationToken cancellationToken)
        {

            var roles = request.AdminCreationDto.Roles;
            var applicationRoles = _mapper.Map<List<ApplicationRole>>(roles);


            var applicationUser = _mapper.Map<ApplicationUser>(request.AdminCreationDto);

            var user = await _userRepository.CreateAdminUserAsync(applicationUser, request.AdminCreationDto.Password, applicationRoles);
            var userDto = _mapper.Map<AdminUserDto>(user);

            var response = new BaseResponse<AdminUserDto>();
            response.Success = true;
            response.Message = "User Created Successfully";
            response.Value = userDto;
            return response;
        }
    }
}