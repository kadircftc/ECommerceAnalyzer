
using Business.Handlers.TrendyolProductTags.Commands;
using FluentValidation;

namespace Business.Handlers.TrendyolProductTags.ValidationRules
{

    public class CreateTrendyolProductTagValidator : AbstractValidator<CreateTrendyolProductTagCommand>
    {
        public CreateTrendyolProductTagValidator()
        {
            RuleFor(x => x.TagName).NotEmpty();
            RuleFor(x => x.TagCount).NotEmpty();

        }
    }
    public class UpdateTrendyolProductTagValidator : AbstractValidator<UpdateTrendyolProductTagCommand>
    {
        public UpdateTrendyolProductTagValidator()
        {
            RuleFor(x => x.TagName).NotEmpty();
            RuleFor(x => x.TagCount).NotEmpty();

        }
    }
}