using ChatApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Domain.Models
{
    public class UserConversation: BaseEntity
    {
        public int UserConversationId { get; set; }
        public int UserId { get; set; }
        public int ConversationId { get; set; }

        // Navigation properties for User and Conversation
        public User User { get; set; }
        public Conversation Conversation { get; set; }
    }
}
