using ChatApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Application.Contracts.Persistence
{
    public interface IConversationRepository: IGenericRepository<Conversation>
    {
    }
}
