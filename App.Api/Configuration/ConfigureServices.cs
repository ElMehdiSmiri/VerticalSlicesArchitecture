using Microsoft.OpenApi.Models;

namespace App.Api.Configuration
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "App.Api", Version = "v1" });
            });

            //services.AddCors(options =>
            //{
            //    options.AddPolicy("CorsPolicy",
            //        builder => builder
            //            .AllowAnyOrigin()
            //            .AllowAnyMethod()
            //            .AllowAnyHeader());
            //});

            //services.AddControllersWithViews(options => options.Filters.Add<ApiExceptionFilterAttribute>());
            //services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);
            //services.AddValidatorsFromAssembly(Assembly.Load("App.Application"));

            return services;
        }
    }
}
