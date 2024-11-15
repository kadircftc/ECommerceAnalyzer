
using Business.Handlers.TrendyolProductBadges.Commands;
using FluentValidation;

namespace Business.Handlers.TrendyolProductBadges.ValidationRules
{

    public class CreateTrendyolProductBadgeValidator : AbstractValidator<CreateTrendyolProductBadgeCommand>
    {
        public CreateTrendyolProductBadgeValidator()
        {
            RuleFor(x => x.MerchantId).NotEmpty();
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Type).NotEmpty();

        }
    }
    public class UpdateTrendyolProductBadgeValidator : AbstractValidator<UpdateTrendyolProductBadgeCommand>
    {
        public UpdateTrendyolProductBadgeValidator()
        {
            RuleFor(x => x.MerchantId).NotEmpty();
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Type).NotEmpty();

        }
    }
}