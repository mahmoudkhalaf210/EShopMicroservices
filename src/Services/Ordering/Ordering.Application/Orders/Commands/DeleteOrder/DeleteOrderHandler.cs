

namespace Ordering.Application.Orders.Commands.DeleteOrder
{
    public class DeleteOrderHandler(IApplicationDbcontext dbContext)
        : ICommandHandler<DeleteOrderCommand, DeleteOrderResult>
    {
        public async Task<DeleteOrderResult> Handle(DeleteOrderCommand command, CancellationToken cancellationToken)
        {
            var orderId = OrderId.Of(command.orderId);
            var order = await dbContext.Orders.FindAsync([orderId], cancellationToken: cancellationToken);

            if (order is null)
                throw new OrderNotFoundException(orderId.ToString());
            
            dbContext.Orders.Remove(order);
            await dbContext.SaveChangesAsync(cancellationToken);

            return new DeleteOrderResult(true);
        }
    }
}
