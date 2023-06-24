using ChatApp.Application.Common.Dtos.ConversationDtos;
using ChatApp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Application.Features.ConversationFeature.Queries
{
    public class ConversationWithUserIdQuery: IRequest<BaseResponse<ConversationDto>>
    {
        public string SenderId;
        public string ReceiverId;
    }
}
