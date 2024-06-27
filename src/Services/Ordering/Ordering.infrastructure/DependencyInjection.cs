
using Microsoft.EntityFrameworkCore.Diagnostics;
using Ordering.Application.Data;
using Ordering.infrastructure.Data.Interceptors;

namespace Ordering.infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddinfrastructureServices(this IServiceCollection services , IConfiguration configuration) {

            var ConnectionString = configuration.GetConnectionString("Database");

            services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
            services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventInterceptor>();


            services.AddDbContext<ApplicationDbContext>((sp,options) =>
            {
                options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
                options.UseSqlServer(ConnectionString);
            });
            services.AddScoped<IApplicationDbcontext, ApplicationDbContext>();


            return services;
        }
    }
}
