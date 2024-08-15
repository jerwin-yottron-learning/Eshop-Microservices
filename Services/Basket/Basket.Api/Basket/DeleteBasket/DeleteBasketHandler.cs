using FluentValidation;
using MediatR;

namespace Basket.Api.Basket.DeleteBasket
{
    public record DeleteBasketCommand(string username):ICommand<DeleteBasketResult>;
    public record DeleteBasketResult (bool IsSuccess);
    public class DeleteBasketCommandValidator : AbstractValidator<DeleteBasketCommand>
    {
        public DeleteBasketCommandValidator() {

            RuleFor(x => x.username).NotEmpty().WithMessage("username is requried");
        }
    }

    public class DeleteBasketCommandHandler : ICommandHandler<DeleteBasketCommand, DeleteBasketResult>
    {
        public async Task<DeleteBasketResult> Handle(DeleteBasketCommand command, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
