using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Persistence
{
    public class ChatAppDbContextFactory : IDesignTimeDbContextFactory<ChatAppDbContext>
    {
        public ChatAppDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory() + "/../ChatApp.WebApi/")
                    .AddJsonFile("appsettings.json")
                    .Build();

            var builder = new DbContextOptionsBuilder<ChatAppDbContext>();
            var connectionString = configuration.GetConnectionString("ConnectionString");

            builder.UseNpgsql(connectionString, o => o.UseNetTopologySuite());

            return new ChatAppDbContext(builder.Options);
        }
    }
}
