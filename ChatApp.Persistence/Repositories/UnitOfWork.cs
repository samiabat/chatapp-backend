using ChatApp.Application.Contracts.Persistence;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Persistence.Repositories
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly ChatAppDbContext _context;
        private readonly IConfiguration _configuration;



        public UnitOfWork(ChatAppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        private IMessageRepository? _messageRepository;
        private IConversationRepository? _conversationRepository;

        public IMessageRepository MessageRepository
        {
            get
            {
                if (_messageRepository == null)
                    _messageRepository = new MessageRepository(_context);
                return _messageRepository;
            }
        }

        public IConversationRepository ConversationRepository
        {
            get
            {
                if (_conversationRepository == null)
                    _conversationRepository = new ConversationRepository(_context);
                return _conversationRepository;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
