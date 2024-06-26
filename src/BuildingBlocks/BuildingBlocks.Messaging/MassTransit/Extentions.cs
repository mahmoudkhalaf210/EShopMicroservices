
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BuildingBlocks.Messaging.MassTransit
{
    public static class Extentions
    {

        public static IServiceCollection AddMessageBroker(this IServiceCollection services , Assembly? assembly = null ) 
        {

            return services;
        }

    }
}
