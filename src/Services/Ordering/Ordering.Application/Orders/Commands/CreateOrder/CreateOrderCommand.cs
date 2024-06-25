



namespace Ordering.Application.Orders.Commands.CreateOrder
{
    public record CreateOrderCommand(OrderDto order) 
        : ICommand<CreateOrderResult>;

    public record CreateOrderResult(Guid Id);

    public class CreateOrderCommandValidation : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidation()
        {
            RuleFor(o => o.order.OrderName).NotEmpty().WithMessage("Name is required");
            RuleFor(o => o.order.CustomerId).NotNull().WithMessage("CustomerId is required");
            RuleFor(o => o.order.orderItems).NotEmpty().WithMessage("OrderItems is required");

        }
    }



}
