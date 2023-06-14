﻿using ChatApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Domain.Models
{
    public class Conversation: BaseEntity
    {
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        // public User Sender { get; set; }
        // public User Receiver { get; set; }
        public ICollection<Message>? Messages { get; set; }
    }
}