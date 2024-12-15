using Microsoft.Extensions.DependencyInjection;
using SocalMedia.Business.Services.Abstractions;
using SocalMedia.Business.Services.Abstractions.Generic;
using SocalMedia.Business.Services.Implementations;
using SocalMedia.Business.Services.Implementations.Generic;
using SocalMedia.Business.UiServices.Abstractions;
using SocalMedia.Business.UiServices.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SocalMedia.Business.ServiceRegistrations
{
    public static class BusinessLogicLayerServiceRegistration
    {
        public static IServiceCollection AddBllServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
           
            services.AddScoped<ICloudinaryManager,CloudinaryManager>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped(typeof(ICrudService<,,,>), typeof(CrudService<,,,>));

            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<ICommentLikeService, CommentLikeService>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped<IStoryService, StoryService>();
            services.AddScoped<IStoryVideoService, StoryVideoService>();
            services.AddScoped<IPostImageService, PostImageService>();
            services.AddScoped<IPostVideoService, PostVideoService>();




            return services;
        }
    }
}
