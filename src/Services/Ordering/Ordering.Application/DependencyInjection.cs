using BuildingBlocks.Behaviours;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services) {


            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
              //  config.AddOpenBehavior(typeof(ValidationBehaviour<,>));
              //  config.AddOpenBehavior(typeof(LoggingBehavior<,>));

            });

            return services;
        }
    }
}
