
namespace Ordering.Application.Orders.Commands.DeleteOrder
{
    public record DeleteOrderCommand(Guid orderId)
        :ICommand<DeleteOrderResult>;

    public record DeleteOrderResult(bool IsSuccess);


    public class DeleteOrderCommandValidator : AbstractValidator<DeleteOrderCommand>
    {
        public DeleteOrderCommandValidator()
        {
            RuleFor(o => o.orderId).NotEmpty().WithMessage("orderId is required");
        }
    }


}
