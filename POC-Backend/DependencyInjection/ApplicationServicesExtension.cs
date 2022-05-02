using POC_Backend.Application.Interfaces;
using POC_Backend.Application.Services;

namespace POC_Backend.DependencyInjection
{
    public static class ApplicationServicesExtension
    {
        public static IServiceCollection AddApplicationServices(
           this IServiceCollection services)
        {
            services.AddScoped<IAnswerService, AnswerService>();
            services.AddScoped<IGroupService, GroupService>();
            services.AddScoped<IPostService, PostService>();

            return services;
        }
    }
}
