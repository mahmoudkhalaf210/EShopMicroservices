using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddinfrastructureServices(this IServiceCollection services , IConfiguration configuration) {

            var ConnectionString = configuration.GetConnectionString("Database");

            /* services.AddDbContext<ApplicationDbContext>(options => {
                 options.UseSqlServer(ConnectionString);
             });
            services.AddScoped<IApplicationDbContext , ApplicationDbContext>();
             */

            return services;
        }
    }
}
