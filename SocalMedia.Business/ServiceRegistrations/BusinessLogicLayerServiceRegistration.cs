using Microsoft.Extensions.DependencyInjection;
using SocalMedia.Business.Services.Abstractions;
using SocalMedia.Business.Services.Implementations;
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
           
           

            return services;
        }
    }
}
