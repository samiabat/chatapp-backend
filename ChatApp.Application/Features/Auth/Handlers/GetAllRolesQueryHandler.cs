
using AutoMapper;
using ChatApp.Application.Common.Dtos.Security;
using ChatApp.Application.Features.Auth.Queries;
using ChatApp.Application.Responses;
using ChatApp.Domain.AuthModel;
using MediatR;
using Microsoft.AspNetCore.Identity;


namespace ChatApp.Application.Features.Auth.Handlers
{

    public sealed class GetAllRolesQueryHandler : IRequestHandler<GetAllRolesQuery, BaseResponse<List<RoleDto>>>
    {
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IMapper _mapper;

        public GetAllRolesQueryHandler(RoleManager<ApplicationRole> roleManager, IMapper mapper)
        {
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public async Task<BaseResponse<List<RoleDto>>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
        {
            var allApplicationRoles = _roleManager.Roles.ToList();
            var allRoles = allApplicationRoles.Select(role => _mapper.Map<RoleDto>(role)).ToList();

            var response = new BaseResponse<List<RoleDto>>();
            response.Success = true;
            response.Message = "Logged In Successfully";
            response.Value = allRoles;
            return response;

        }
    }
}