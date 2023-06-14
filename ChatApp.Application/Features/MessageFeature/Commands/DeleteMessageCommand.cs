using ChatApp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Application.Features.MessageFeature.Commands
{
    public class DeleteMessageCommand: IRequest<BaseResponse<int>>
    {
        public int Id { get; set; }
    }
}
