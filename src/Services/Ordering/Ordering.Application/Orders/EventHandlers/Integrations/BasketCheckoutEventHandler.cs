
using BuildingBlocks.Messaging.Events;
using MassTransit;
using Ordering.Application.Orders.Commands.CreateOrder;

namespace Ordering.Application.Orders.EventHandlers.Integrations
{
    public class BasketCheckoutEventHandler
        (ISender sender , ILogger<BasketCheckoutEventHandler> logger)
        : IConsumer<BasketCheckoutEvent>
    {
        public async Task Consume( ConsumeContext<BasketCheckoutEvent> context)
        {
            // create new order and start order fullfillment process
            logger.LogInformation("Integration Event Handled: {IntegrationEvent}" , context.Message.GetType().Name);

            var command = MapToOrderCommand(context.Message);
            await sender.Send(command);


            throw new NotImplementedException();
        }


        private CreateOrderCommand MapToOrderCommand(BasketCheckoutEvent message) {

            var addressDto = new AddressDto(message.FirstName, message.LastName, message.EmailAddress, message.Addressline, message.Country, message.State, message.ZipCode);
            var paymentDto = new PaymentDto(message.CardName, message.CardNumber, message.Expiration, message.CVV, message.PaymentMethod);

            var orderId = Guid.NewGuid();

            var orderDto = new OrderDto(
                Id: orderId,
                CustomerId: message.CustomerId,
                OrderName: message.UserName,
                ShippingAddress: addressDto,
                BillingAddress: addressDto,
                Payment: paymentDto,
                status: Ordering.Domain.Enums.OrderStatus.Pending,
                orderItems: [
                    new OrderItemDto(orderId , new Guid("01900EE4-0BE4-4797-8222-494D7131F325") , 2 , 400)
                    ]
                );

            return new CreateOrderCommand(orderDto);
        }



    }
}
