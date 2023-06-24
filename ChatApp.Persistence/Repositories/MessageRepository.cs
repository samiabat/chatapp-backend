using ChatApp.Application.Common.Dtos.MessageDto;
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
    public class MessageRepository : GenericRepository<Message>, IMessageRepository
    {
        private readonly ChatAppDbContext _dbContext;
        public MessageRepository(ChatAppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<MessageDto>> MessageByConversationId(int id)
        {
            return await _dbContext.Set<MessageDto>()
                .Where(x => x.ConversationId == id)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
