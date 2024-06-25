
using Ordering.infrastructure.Data.Interceptors;

namespace Ordering.infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddinfrastructureServices(this IServiceCollection services , IConfiguration configuration) {

            var ConnectionString = configuration.GetConnectionString("Database");

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.AddInterceptors(new AuditableEntityInterceptor());
                options.UseSqlServer(ConnectionString);
            });
/*            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
*/

            return services;
        }
    }
}
