using Microsoft.Extensions.DependencyInjection;
using SocalMedia.Business.Services.Abstractions;
using SocalMedia.Business.Services.Abstractions.Generic;
using SocalMedia.Business.Services.Implementations;
using SocalMedia.Business.Services.Implementations.Generic;
using SocalMedia.Business.UiServices.Abstractions;
using SocalMedia.Business.UiServices.Implementations;
using SocialMedia.Core.Entities;
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

            services.AddScoped<IPostImageService, PostImageService>();
            services.AddScoped<IPostVideoService, PostVideoService>();
            services.AddScoped<IPostService, PostService>();

            services.AddScoped<IMessageService, MessageService>();

            services.AddScoped<IStoryService, StoryService>();

            services.AddScoped<IStoryVideoService, StoryVideoService>();

            services.AddScoped<IFollowService, FollowService>();

            services.AddScoped<IHomeService, HomeService>();

            services.AddScoped<IProfileService, ProfileService>();

            services.AddScoped<IFriendService, FriendService>();

            services.AddScoped<IAccountService, AccountService>(); 

            services.AddScoped<IChatService, ChatService>(); 

            services.AddScoped<IPostLikeService, PostLikeService>();

            services.AddScoped<ISendNatficationService, SendNatficationService>();

            return services;
        }
    }
}
