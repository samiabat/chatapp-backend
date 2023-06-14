using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Application.Contracts.Persistence
{
    public interface IUnitOfWork: IDisposable
    {
        IMessageRepository MessageRepository { get; }
        IConversationRepository ConversationRepository { get; }
        IUserConversationRepository UserConversationRepository { get; }
        IUserRepository UserRepository { get; }
        Task<int> Save();
    }
}
