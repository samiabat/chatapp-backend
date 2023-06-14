using ChatApp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Application.Features.ConversationFeature.Commands
{
    public class DeleteConversationCommand: IRequest<BaseResponse<int>>
    {
        public int Id { get; set; }
    }
}
