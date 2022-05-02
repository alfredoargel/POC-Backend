using POC_Backend.Infrastructure.Data.Context;
using POC_Backend.Infrastructure.Data.MongoDB;

namespace POC_Backend.DependencyInjection
{
    public static class MongoDbInfrastructureExtension
    {
        public static IServiceCollection AddMongoDbPersistence(
          this IServiceCollection services,
          IConfiguration configuration)
        {
            var config = new ServerConfig();
            configuration.Bind(config);
            services.AddScoped<DBContext>(s => new DBContext(config.MongoDB));

            return services;
        }
    }
}
