using DAW_Lab4.Helpers.Seeders;
using DAW_Lab4.Repositories.UserRepository;
using DAW_Lab4.Services.UserService;
using System.Runtime.CompilerServices;

namespace DAW_Lab4.Helpers.Extensions
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

        public static IServiceCollection AddSeeders (this IServiceCollection services)
        {
            services.AddTransient < UsersSeeder>();

            return services;
        }
    }
}
