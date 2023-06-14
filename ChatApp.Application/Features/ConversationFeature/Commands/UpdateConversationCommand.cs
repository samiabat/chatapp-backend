using ChatApp.Application.Common.Dtos.ConversationDtos;
using ChatApp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Application.Features.ConversationFeature.Commands
{
    public class UpdateConversationCommand: IRequest<BaseResponse<int>>
    {
        public UpdateConversationDto conversationDto { get; set; }
    }
}
