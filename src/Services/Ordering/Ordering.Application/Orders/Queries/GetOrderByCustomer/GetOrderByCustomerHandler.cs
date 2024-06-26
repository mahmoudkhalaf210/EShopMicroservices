


namespace Ordering.Application.Orders.Queries.GetOrderByCustomer
{
    public class GetOrderByCustomerHandler(IApplicationDbcontext dbContext)
        : IQueryHandler<GetOrderByCustomerQuery, GetOrderByCustomerResult>
    {
        public async Task<GetOrderByCustomerResult> Handle(GetOrderByCustomerQuery query, CancellationToken cancellationToken)
        {
            var orders = await dbContext.Orders
                        .Include(o => o.OrderItems)
                        .AsNoTracking()
                        .Where(o => o.CustomerId == CustomerId.Of(query.customerId))
                        .OrderBy(o => o.OrderName.Value)
                        .ToListAsync(cancellationToken);
            return new GetOrderByCustomerResult(orders.ToOrderDtoList());

        }
    }
}
