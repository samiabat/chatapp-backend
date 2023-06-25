using ChatApp.Application.Common.Dtos.Security;
using ChatApp.Application.Responses;
using ChatApp.Domain.AuthModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Application.Features.Auth.Queries
{
    public class GetUserByIdQuery: IRequest<BaseResponse<UserDtailDto>>
    {
        public string UserId { get; set; }
    }
}
