using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Domain.Models
{
    public class Conversation: BaseEntity
    {
        public int ConversationId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation property for UserConversation relationship
        public ICollection<UserConversation> UserConversations { get; set; }

        // Navigation property for Message relationship
        public ICollection<Message> Messages { get; set; }
    }
}
