using MagazinAlimentar.Helpers.JwtUtils;
using MagazinAlimentar.Repositories.UserRepository;
using MagazinAlimentar.Services.UserService;

namespace MagazinAlimentar.Helpers.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();

            return services;
        }

        public static IServiceCollection AddJwtUtils(this IServiceCollection services)
        {
            services.AddScoped<IJwtUtils, JwtUtils.JwtUtils>();

            return services;
        }
    }
}
