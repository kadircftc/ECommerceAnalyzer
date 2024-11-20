using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class TrendyolProductTransferDto:IDto
    {
        public int ProductId { get; set; }
        public string CategoryHierarchy { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int FavoriteCount { get; set; }
        public int OrderCount { get; set; }
        public int PageViewCount { get; set; }
        public int BasketCount { get; set; }
        public int MerchantId { get; set; }
        public int CampaignId { get; set; }
        public string ListingId { get; set; }
        public bool SameDayShipping { get; set; }
        public string PriceLabelName { get; set; }
        public string PriceLabelValue { get; set; }
        public string ProductUrl { get; set; }
        public string ProductName { get; set; }
        public string BrandName { get; set; }
        public int Tax { get; set; }
        public decimal AvarageRating { get; set; }
        public int RatingTotalCount { get; set; }
        public int ProductGroupId { get; set; }
        public decimal BuyingPrice { get; set; }
        public string Currency { get; set; }
        public decimal DiscountPrice { get; set; }
        public decimal OriginalPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public int RushDeliveryDuration { get; set; }
        public int CommentCount { get; set; }
        public bool FreeCargo { get; set; }
        public string CampaignName { get; set; }
        public string WinnerVariant { get; set; }
        public int PIndex { get; set; }
        public bool HasCategoryTopRankings { get; set; }
        public bool HasPromotions { get; set; }
        public string SortType { get; set; }
        public bool HasPriceLabels { get; set; }
        public bool HasCollectableCoupon { get; set; }
        public bool HasBadges { get; set; }
        public List<string> Images { get; set; }
        public List<Dictionary<string,List<TrendyolProductBadge>>> Badges { get; set; }
        public List<Dictionary<string,List<TrendyolProductLastSocialProof>>> LastSocialProof { get; set; }
        public List<Dictionary<string,List<TrendyolProductTag>>> Tags { get; set; }
    }
}
