using ChatApp.Application.Common.Dtos.ConversationDto;
using ChatApp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Application.Features.ConversationFeature.Commands
{
    public class CreateConversationCommand: IRequest<BaseResponse<int>>
    {
        public CreateConversationDto conversationDto { get; set; }
    }
}
