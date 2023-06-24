using ChatApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Application.Common.Dtos.ConversationDtos
{
    public class UpdateConversationDto
    {
        public int Id { get; set; }
        public string SenderId { get; set; }
        public string ReceiverId { get; set; }
        // public User Sender { get; set; }
        // public User Receiver { get; set; }
        public ICollection<Message>? Messages { get; set; }
    }
}
