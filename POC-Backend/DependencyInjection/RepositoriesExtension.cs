using POC_Backend.Application.Interfaces;
using POC_Backend.Infrastructure;
using POC_Backend.Infrastructure.Repositories;

namespace POC_Backend.DependencyInjection
{
    public static class RepositoriesExtension
    {
        public static IServiceCollection AddRepositories(
           this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAnswerRepository, AnswerRepository>();
            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddScoped<IPostRepository, PostRepository>();

            return services;
        }
    }
}
