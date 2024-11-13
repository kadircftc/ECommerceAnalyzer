
using Business.Handlers.TrendyolProductLastSocialProoves.Commands;
using FluentValidation;

namespace Business.Handlers.TrendyolProductLastSocialProoves.ValidationRules
{

    public class CreateTrendyolProductLastSocialProofValidator : AbstractValidator<CreateTrendyolProductLastSocialProofCommand>
    {
        public CreateTrendyolProductLastSocialProofValidator()
        {
            RuleFor(x => x.FavoriteCount).NotEmpty();
            RuleFor(x => x.OrderCount).NotEmpty();
            RuleFor(x => x.BasketCount).NotEmpty();
            RuleFor(x => x.PageViewCount).NotEmpty();

        }
    }
    public class UpdateTrendyolProductLastSocialProofValidator : AbstractValidator<UpdateTrendyolProductLastSocialProofCommand>
    {
        public UpdateTrendyolProductLastSocialProofValidator()
        {
            RuleFor(x => x.FavoriteCount).NotEmpty();
            RuleFor(x => x.OrderCount).NotEmpty();
            RuleFor(x => x.BasketCount).NotEmpty();
            RuleFor(x => x.PageViewCount).NotEmpty();

        }
    }
}