using FluentValidation;

namespace Stock.Business.Commands.UpdateProduct
{
    public class RequestValidator : AbstractValidator<Request>
    {
        public RequestValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }
}
