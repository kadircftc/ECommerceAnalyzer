
using Business.Handlers.TrendyolProducts.Commands;
using FluentValidation;

namespace Business.Handlers.TrendyolProducts.ValidationRules
{

    public class CreateTrendyolProductValidator : AbstractValidator<CreateTrendyolProductCommand>
    {
        public CreateTrendyolProductValidator()
        {
            RuleFor(x => x.CategoryHierarchy).NotEmpty();
            RuleFor(x => x.CategoryId).NotEmpty();
            RuleFor(x => x.CategoryName).NotEmpty();
            RuleFor(x => x.FavoriteCount).NotEmpty();
            RuleFor(x => x.OrderCount).NotEmpty();
            RuleFor(x => x.PageViewCount).NotEmpty();
            RuleFor(x => x.BasketCount).NotEmpty();
            RuleFor(x => x.MerchantId).NotEmpty();
            RuleFor(x => x.CampaignId).NotEmpty();
            RuleFor(x => x.ListingId).NotEmpty();
            RuleFor(x => x.SameDayShipping).NotEmpty();
            RuleFor(x => x.PriceLabelName).NotEmpty();
            RuleFor(x => x.PriceLabelValue).NotEmpty();
            RuleFor(x => x.ProductUrl).NotEmpty();
            RuleFor(x => x.ProductName).NotEmpty();
            RuleFor(x => x.BrandName).NotEmpty();
            RuleFor(x => x.Tax).NotEmpty();
            RuleFor(x => x.AvarageRating).NotEmpty();
            RuleFor(x => x.RatingTotalCount).NotEmpty();
            RuleFor(x => x.ProductGroupId).NotEmpty();
            RuleFor(x => x.BuyingPrice).NotEmpty();
            RuleFor(x => x.Currency).NotEmpty();
            RuleFor(x => x.DiscountPrice).NotEmpty();
            RuleFor(x => x.OriginalPrice).NotEmpty();
            RuleFor(x => x.SellingPrice).NotEmpty();
            RuleFor(x => x.RushDeliveryDuration).NotEmpty();
            RuleFor(x => x.CommentCount).NotEmpty();
            RuleFor(x => x.FreeCargo).NotEmpty();
            RuleFor(x => x.CampaignName).NotEmpty();
            RuleFor(x => x.WinnerVariant).NotEmpty();
            RuleFor(x => x.PIndex).NotEmpty();

        }
    }
    public class UpdateTrendyolProductValidator : AbstractValidator<UpdateTrendyolProductCommand>
    {
        public UpdateTrendyolProductValidator()
        {
            RuleFor(x => x.CategoryHierarchy).NotEmpty();
            RuleFor(x => x.CategoryId).NotEmpty();
            RuleFor(x => x.CategoryName).NotEmpty();
            RuleFor(x => x.FavoriteCount).NotEmpty();
            RuleFor(x => x.OrderCount).NotEmpty();
            RuleFor(x => x.PageViewCount).NotEmpty();
            RuleFor(x => x.BasketCount).NotEmpty();
            RuleFor(x => x.MerchantId).NotEmpty();
            RuleFor(x => x.CampaignId).NotEmpty();
            RuleFor(x => x.ListingId).NotEmpty();
            RuleFor(x => x.SameDayShipping).NotEmpty();
            RuleFor(x => x.PriceLabelName).NotEmpty();
            RuleFor(x => x.PriceLabelValue).NotEmpty();
            RuleFor(x => x.ProductUrl).NotEmpty();
            RuleFor(x => x.ProductName).NotEmpty();
            RuleFor(x => x.BrandName).NotEmpty();
            RuleFor(x => x.Tax).NotEmpty();
            RuleFor(x => x.AvarageRating).NotEmpty();
            RuleFor(x => x.RatingTotalCount).NotEmpty();
            RuleFor(x => x.ProductGroupId).NotEmpty();
            RuleFor(x => x.BuyingPrice).NotEmpty();
            RuleFor(x => x.Currency).NotEmpty();
            RuleFor(x => x.DiscountPrice).NotEmpty();
            RuleFor(x => x.OriginalPrice).NotEmpty();
            RuleFor(x => x.SellingPrice).NotEmpty();
            RuleFor(x => x.RushDeliveryDuration).NotEmpty();
            RuleFor(x => x.CommentCount).NotEmpty();
            RuleFor(x => x.FreeCargo).NotEmpty();
            RuleFor(x => x.CampaignName).NotEmpty();
            RuleFor(x => x.WinnerVariant).NotEmpty();
            RuleFor(x => x.PIndex).NotEmpty();

        }
    }
}