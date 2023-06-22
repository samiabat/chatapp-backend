
using AutoMapper;
using ChatApp.Application.Common.Dtos.Security;
using ChatApp.Application.Contracts.Identity;
using ChatApp.Application.Features.Auth.Queries;
using ChatApp.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace ChatApp.Application.Features.Auth.Handlers
{

    public sealed class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, BaseResponse<List<UserDto>>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetAllUsersQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<List<UserDto>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var allApplicationUsers = await _userRepository.GetUsersAsync();
            var allRoles = allApplicationUsers.Select(user => _mapper.Map<UserDto>(user)).ToList();

            var response = new BaseResponse<List<UserDto>>();
            response.Success = true;
            response.Message = "Fetched In Successfully";
            response.Value = allRoles;
            return response;

        }
    }
}