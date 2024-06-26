

namespace Ordering.Application.Orders.Queries.GetOrderByName
{
    public class GetOrderByNameHandler(IApplicationDbcontext dbcontext)
        : IQueryHandler<GetOrderByNameQuery, GetOrderByNameResult>
    {
        public async Task<GetOrderByNameResult> Handle(GetOrderByNameQuery query, CancellationToken cancellationToken)
        {
            var orders = await dbcontext.Orders
                        .Include(o => o.OrderItems)
                        .AsNoTracking()
                        .Where(o => o.OrderName.Value == query.Name)
                        .OrderBy(o => o.OrderName.Value)
                        .ToListAsync();

            return new GetOrderByNameResult(orders.ToOrderDtoList());
        }


  
    }
}
