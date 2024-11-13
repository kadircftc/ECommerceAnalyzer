using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Entities.Dtos
{
    public class Product
    {
        [JsonProperty("showSexualContent")]
        public bool ShowSexualContent { get; set; }

        [JsonProperty("sections")]
        public List<Section>? Sections { get; set; }

        [JsonProperty("categoryHierarchy")]
        public string? CategoryHierarchy { get; set; }

        [JsonProperty("categoryId")]
        public int CategoryId { get; set; }

        [JsonProperty("categoryName")]
        public string? CategoryName { get; set; }

        [JsonProperty("socialProof")]
        public SocialProof? SocialProof { get; set; }

        [JsonProperty("variants")]
        public List<Variant>? Variants { get; set; }

        [JsonProperty("url")]
        public string? Url { get; set; }

        [JsonProperty("stamps")]
        public List<Stamp>? Stamps { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("images")]
        public List<string>? Images { get; set; }

        [JsonProperty("imageAlt")]
        public string ImageAlt { get; set; }

        [JsonProperty("brand")]
        public Brand Brand { get; set; }

        [JsonProperty("tax")]
        public int Tax { get; set; }

        [JsonProperty("ratingScore")]
        public RatingScore RatingScore { get; set; }

        [JsonProperty("productGroupId")]
        public int ProductGroupId { get; set; }

        [JsonProperty("hasReviewPhoto")]
        public bool HasReviewPhoto { get; set; }

        [JsonProperty("cardType")]
        public string CardType { get; set; }

        [JsonProperty("merchantId")]
        public int MerchantId { get; set; }

        [JsonProperty("campaignId")]
        public int CampaignId { get; set; }

        [JsonProperty("price")]
        public Price Price { get; set; }

        [JsonProperty("promotions")]
        public List<Promotion> Promotions { get; set; }

        [JsonProperty("rushDeliveryDuration")]
        public int RushDeliveryDuration { get; set; }

        [JsonProperty("freeCargo")]
        public bool FreeCargo { get; set; }

        [JsonProperty("campaignName")]
        public string CampaignName { get; set; }

        [JsonProperty("listingId")]
        public string ListingId { get; set; }

        [JsonProperty("winnerVariant")]
        public string WinnerVariant { get; set; }

        [JsonProperty("itemNumber")]
        public long ItemNumber { get; set; }

        [JsonProperty("discountedPriceInfo")]
        public string DiscountedPriceInfo { get; set; }

        [JsonProperty("hasVideoContent")]
        public bool HasVideoContent { get; set; }

        [JsonProperty("hasCrossPromotion")]
        public bool HasCrossPromotion { get; set; }

        [JsonProperty("hasCollectableCoupon")]
        public bool HasCollectableCoupon { get; set; }

        [JsonProperty("sameDayShipping")]
        public bool SameDayShipping { get; set; }

        [JsonProperty("isLegalRequirementConfirmed")]
        public bool IsLegalRequirementConfirmed { get; set; }

        [JsonProperty("badges")]
        public List<Badge> Badges { get; set; }

        [JsonProperty("categoryTopRankings")]
        public List<CategoryTopRanking> CategoryTopRankings { get; set; }

        [JsonProperty("dsmColor")]
        public string DsmColor { get; set; }

        [JsonProperty("hasSexualContentBlur")]
        public bool HasSexualContentBlur { get; set; }
    }
}
