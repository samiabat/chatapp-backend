using ChatApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Domain.Models{
    public class User: BaseEntity
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public ICollection<Conversation>? Conversations { get; set; }
    }
}
