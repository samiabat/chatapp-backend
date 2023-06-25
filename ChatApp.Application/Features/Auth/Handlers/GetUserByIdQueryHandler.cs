using AutoMapper;
using ChatApp.Application.Common.Dtos.MessageDto;
using ChatApp.Application.Common.Dtos.Security;
using ChatApp.Application.Contracts.Identity;
using ChatApp.Application.Features.Auth.Queries;
using ChatApp.Application.Responses;
using ChatApp.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Application.Features.Auth.Handlers
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, BaseResponse<UserDtailDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserByIdQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<UserDtailDto>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var applicationUser = await _userRepository.GetUserById(request.UserId);
            var response = new BaseResponse<UserDtailDto>();
            response.Success = true;
            response.Message = "Fetched In Successfully";
            response.Value = _mapper.Map<UserDtailDto>(applicationUser);
            return response;
        }
    }
}
