
namespace Ordering.Application.Extentions
{
    public static class OrderExtentions
    {
        public static IEnumerable<OrderDto> ToOrderDtoList(this IEnumerable<Order> orders) {

            return orders.Select(order => new OrderDto(
                            Id: order.Id.Value,
                            CustomerId: order.CustomerId.Value,
                            OrderName: order.OrderName.Value,
                            ShippingAddress: new AddressDto(
                                FirstName: order.ShippingAddress.FirstName,
                                LastName: order.ShippingAddress.LastName,
                                EmailAddress: order.ShippingAddress.EmailAddress,
                                AddressLine: order.ShippingAddress.AddressLine,
                                Country: order.ShippingAddress.Country,
                                State: order.ShippingAddress.State,
                                ZipCOde: order.ShippingAddress.ZipCOde
                                ),
                            BillingAddress: new AddressDto(
                                FirstName: order.BillingAddress.FirstName,
                                LastName: order.BillingAddress.LastName,
                                EmailAddress: order.BillingAddress.EmailAddress,
                                AddressLine: order.BillingAddress.AddressLine,
                                Country: order.BillingAddress.Country,
                                State: order.BillingAddress.State,
                                ZipCOde: order.BillingAddress.ZipCOde
                                ),
                            Payment: new PaymentDto(
                                CardName: order.Payment.CardName,
                                CardNumber: order.Payment.CardNumber,
                                Expiration: order.Payment.Expiration,
                                Cvv: order.Payment.CVV,
                                Paymentmethod: order.Payment.PaymentMethod
                                ),
                            status: order.Status,
                            orderItems: order.OrderItems.Select(oi => new OrderItemDto(oi.OrderId.Value, oi.ProductId.Value, oi.Quantity, oi.Price)).ToList()
                            )
            );
        }
    }
}
