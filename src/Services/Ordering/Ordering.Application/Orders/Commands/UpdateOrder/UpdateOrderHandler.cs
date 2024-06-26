



namespace Ordering.Application.Orders.Commands.UpdateOrder
{
    public class UpdateOrderHandler(IApplicationDbcontext dbContext)
        : ICommandHandler<UpdateOrderCommand, UpdateOrderResult>
    {
        public async Task<UpdateOrderResult> Handle(UpdateOrderCommand command, CancellationToken cancellationToken)
        {
            var orderId = OrderId.Of(command.order.Id);
            var order = await dbContext.Orders
                            .FindAsync([orderId], cancellationToken: cancellationToken);
            if (order is null)
            {
                throw new OrderNotFoundException(command.order.Id.ToString());
            }


            UpdateOrdersWithNewValue(order ,command.order);

            dbContext.Orders.Update(order);
            await dbContext.SaveChangesAsync(cancellationToken);
            return new UpdateOrderResult(true);

        }


        public void UpdateOrdersWithNewValue(Order order, OrderDto orderDto) { 
        var UpdatedShippingAddress = Address.Of(orderDto.ShippingAddress.FirstName
                , orderDto.ShippingAddress.LastName
                , orderDto.ShippingAddress.EmailAddress,
                orderDto.ShippingAddress.AddressLine,
                orderDto.ShippingAddress.Country,
                orderDto.ShippingAddress.State,
                orderDto.ShippingAddress.ZipCOde
                );

        var UpdatedBillingAddress = Address.Of(orderDto.BillingAddress.FirstName
                                   , orderDto.BillingAddress.LastName
                                   , orderDto.BillingAddress.EmailAddress,
                                   orderDto.BillingAddress.AddressLine,
                                   orderDto.BillingAddress.Country,
                                   orderDto.BillingAddress.State,
                                   orderDto.BillingAddress.ZipCOde
                                                                );


        var UpdatedPayment = Payment.Of(orderDto.Payment.CardName, orderDto.Payment.CardNumber, orderDto.Payment.Expiration, orderDto.Payment.Cvv, orderDto.Payment.Paymentmethod);


            order.Update(OrderName.Of(orderDto.OrderName), UpdatedShippingAddress, UpdatedBillingAddress, UpdatedPayment, orderDto.status);

        }




    }
}
