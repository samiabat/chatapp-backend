﻿using ChatApp.Application.Common.Dtos.MessageDto;
using ChatApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Application.Contracts.Persistence
{
    public interface IMessageRepository: IGenericRepository<Message>
    {
        Task<List<Message>> MessageByConversationId(int ConversationId);
    }
}
