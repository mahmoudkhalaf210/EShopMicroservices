
using BuildingBlocks.Messaging.Events;
using MassTransit;

namespace Basket.API.Basket.CheckoutBasket
{

    public record CheckoutBasketCommand(BasketCheckoutDto basketCheckoutDto) : ICommand<CheckoutBasketResult>;
    public record CheckoutBasketResult(bool IsSuccess);

    public class CheckoutBasketValidator : AbstractValidator<CheckoutBasketCommand>
    {
        public CheckoutBasketValidator()
        {
            RuleFor(x => x.basketCheckoutDto).NotNull().WithMessage("basketCheckoutDto can't be null");
            RuleFor(x => x.basketCheckoutDto.UserName).NotEmpty().WithMessage("UserName is required");

        }
    }
    public class CheckoutBasketHandler (IBasketRepositroy repo , IPublishEndpoint publishEndPoint)
        : ICommandHandler<CheckoutBasketCommand, CheckoutBasketResult>
    {
        public async Task<CheckoutBasketResult> Handle(CheckoutBasketCommand command, CancellationToken cancellationToken)
        {
            // Get existing basket with total price
            // set total price on basketcheckout event message
            // send basket checkout event to rabitmq using transmitt
            // delete the basket

            var basket = await repo.GetBasket(command.basketCheckoutDto.UserName, cancellationToken);
            if (basket is null)
                return new CheckoutBasketResult(false);

            var eventMessage = command.basketCheckoutDto.Adapt<BasketCheckoutEvent>();
            eventMessage.TotalPrice = basket.TotalPrice;

            await publishEndPoint.Publish(eventMessage , cancellationToken);
            await repo.DeleteBasket(command.basketCheckoutDto.UserName, cancellationToken);
            return new CheckoutBasketResult(true);
        }
    }
}
