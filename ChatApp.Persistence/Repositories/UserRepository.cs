using ChatApp.Application.Contracts.Persistence;
using ChatApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Persistence.Repositories
{
    public class UserRepository : GenericRepository<User>,IUserRepository
    {
        public UserRepository(ChatAppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
