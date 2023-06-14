using ChatApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Domain.Models
{
    public class User: BaseEntity
{
    public int UserId { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public DateTime CreatedAt { get; set; }
    // Additional properties such as FirstName, LastName, Email, etc.

    // Navigation property for UserConversation relationship
     public ICollection<UserConversation> UserConversations { get; set; }
    }

}
