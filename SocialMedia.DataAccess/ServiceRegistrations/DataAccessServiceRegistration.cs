using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SocialMedia.DataAccess.Context;


namespace SocialMedia.DataAccess.ServiceRegistrations
{
    public static class DataAccessServiceRegistration
    {
        public static IServiceCollection AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("Default")));

            AddRepositories(services);

            return services;
        }
        private static void AddRepositories(IServiceCollection services)
        {
        }
    }
}
