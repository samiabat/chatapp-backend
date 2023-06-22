using ChatApp.Application.Contracts.Identity;
using ChatApp.Application.Contracts.Persistence;
using ChatApp.Persistence.Repositories;
using ChatApp.Persistence.Repositories.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}
