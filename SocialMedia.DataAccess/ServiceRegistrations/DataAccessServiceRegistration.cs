using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SocialMedia.DataAccess.Context;
using SocialMedia.DataAccess.DataInitalizers;
using SocialMedia.DataAccess.Repositories.Abstraction;
using SocialMedia.DataAccess.Repositories.Implementations;


namespace SocialMedia.DataAccess.ServiceRegistrations
{
    public static class DataAccessServiceRegistration
    {
        public static IServiceCollection AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("Default")));

            //services.AddScoped<DbContextInitalizer>();

            AddRepositories(services);

            return services;
        }
        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IMessageRepository,MessageRepository>();

            services.AddScoped<ICommentLikeRepository,CommentLikeRepository>();
            services.AddScoped<ICommentRepository,CommentRepository>();

            services.AddScoped<IStoryRepository,StoryRepository>();
            services.AddScoped<IStoryVideoRepository,StoryVideoRepository>();

            services.AddScoped<IPostRepository,PostRepository>();
            services.AddScoped<IPostVideoRepository,PostVideoRepository>();
            services.AddScoped<IPostImageRepository,PostImageRepository>();

        }
    }
}
