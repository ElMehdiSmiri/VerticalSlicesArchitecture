using App.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace App.Infrastructure.Common.Configuration
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"),
                x => x.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)).UseLazyLoadingProxies());

            return services;
        }
    }
}
