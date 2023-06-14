﻿using ChatApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Application.Common.Dtos.ConversationDtos
{
    public class ConversationDto
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        // public User Sender { get; set; }
        // public User Receiver { get; set; }
        public ICollection<Message>? Messages { get; set; }
    }
}
