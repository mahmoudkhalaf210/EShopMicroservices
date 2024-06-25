


namespace Ordering.Application.Orders.Commands.UpdateOrder
{
    public record UpdateOrderCommand (OrderDto order)
        :ICommand<UpdateOrderResult>;


    public record  UpdateOrderResult(bool IsSuccess);


    public class UpdateOrderCommandValidator:AbstractValidator<UpdateOrderCommand> {
        public UpdateOrderCommandValidator()
        {
            RuleFor(o => o.order.Id).NotEmpty().WithMessage("Id is required");
            RuleFor(o => o.order.OrderName).NotEmpty().WithMessage("OrderName is required");
            RuleFor(o => o.order.CustomerId).NotNull().WithMessage("CustomerId is required");
        }
    }


}
