using ChatApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Domain.Models
{
    public class Message: BaseEntity
    {
        public int ConversationId { get; set; }
        public Conversation Conversation { get; set; }
        public string Content { get; set; }
    }
}
