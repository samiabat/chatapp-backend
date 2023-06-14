using ChatApp.Application.Contracts.Persistence;
using ChatApp.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection ConfigurePersistenceService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ChatAppDbContext>(opt =>
            opt.UseNpgsql(configuration.GetConnectionString("ConnectionString"), o => o.UseNetTopologySuite()
            .EnableRetryOnFailure()));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
