using MagazinAlimentar.Helpers.JwtUtils;
using MagazinAlimentar.Repositories.DepartmentRepository;
using MagazinAlimentar.Repositories.ProductRepository;
using MagazinAlimentar.Repositories.UserRepository;
using MagazinAlimentar.Services.DepartmentService;
using MagazinAlimentar.Services.UserService;

namespace MagazinAlimentar.Helpers.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IDepartmentRepository, DepartmentRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IDepartmentService, DepartmentService>();

            return services;
        }

        public static IServiceCollection AddJwtUtils(this IServiceCollection services)
        {
            services.AddScoped<IJwtUtils, JwtUtils.JwtUtils>();

            return services;
        }
    }
}
