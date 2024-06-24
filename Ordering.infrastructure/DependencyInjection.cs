
namespace Ordering.infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddinfrastructureServices(this IServiceCollection services , IConfiguration configuration) {

            var ConnectionString = configuration.GetConnectionString("Database");

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(ConnectionString);
            });
/*            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
*/

            return services;
        }
    }
}
