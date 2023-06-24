using ChatApp.Application.Contracts.Persistence;
using ChatApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Persistence.Repositories
{
    public class ConversationRepository : GenericRepository<Conversation>, IConversationRepository
    {
        private readonly ChatAppDbContext _dbContext;
        public ConversationRepository(ChatAppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Conversation> ConversationByUsersId(string SenderId, string ReceiverId)
        {
            var conversations =  await _dbContext.Set<Conversation>()
                .Where(c=>c.SenderId == SenderId && c.ReceiverId == ReceiverId)
                .AsNoTracking()
                .ToListAsync();
            if (conversations.Count == 0)
                return new Conversation();
            return conversations[0];
        }
    }
}
