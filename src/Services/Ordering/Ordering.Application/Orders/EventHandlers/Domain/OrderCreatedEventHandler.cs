using MassTransit;
using Microsoft.FeatureManagement;

namespace Ordering.Application.Orders.EventHandlers.Domain
{
    public class OrderCreatedEventHandler(IPublishEndpoint publishEndPoint,IFeatureManager featureManager ,ILogger<OrderCreatedEventHandler> logger)
        : INotificationHandler<OrderCreatedEvent>
    {
        public async Task Handle(OrderCreatedEvent domainEvent, CancellationToken cancellationToken)
        {
            logger.LogInformation("Domain Event handled: {DomainEvent}", domainEvent.GetType().Name);

            if (await featureManager.IsEnabledAsync("OrderFullfilment")) {
                var orderCreatedIntegrationEvent = domainEvent.order.ToOrderDto();
                await publishEndPoint.Publish(orderCreatedIntegrationEvent, cancellationToken);
            }
          
        }
    }
}
