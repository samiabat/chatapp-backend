﻿using ChatApp.Application.Common.Dtos.MessageDto;
using ChatApp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Application.Features.MessageFeature.Queries
{
    public class GetMessageDetailQuery: IRequest<BaseResponse<MessageDto>>
    {
        public int Id { get; set; }
    }
}
