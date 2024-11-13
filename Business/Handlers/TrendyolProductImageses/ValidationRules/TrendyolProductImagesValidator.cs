
using Business.Handlers.TrendyolProductImageses.Commands;
using FluentValidation;

namespace Business.Handlers.TrendyolProductImageses.ValidationRules
{

    public class CreateTrendyolProductImagesValidator : AbstractValidator<CreateTrendyolProductImagesCommand>
    {
        public CreateTrendyolProductImagesValidator()
        {
            RuleFor(x => x.ImgUrl).NotEmpty();

        }
    }
    public class UpdateTrendyolProductImagesValidator : AbstractValidator<UpdateTrendyolProductImagesCommand>
    {
        public UpdateTrendyolProductImagesValidator()
        {
            RuleFor(x => x.ImgUrl).NotEmpty();

        }
    }
}