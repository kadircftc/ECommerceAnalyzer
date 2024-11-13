using Newtonsoft.Json;

namespace Entities.Dtos
{
    public class Variant
    {
        [JsonProperty("attributeValue")]
        public string AttributeValue { get; set; }

        [JsonProperty("attributeName")]
        public string AttributeName { get; set; }

        [JsonProperty("price")]
        public Price Price { get; set; }

        [JsonProperty("listingId")]
        public string ListingId { get; set; }

        [JsonProperty("campaignId")]
        public int CampaignId { get; set; }

        [JsonProperty("merchantId")]
        public int MerchantId { get; set; }

        [JsonProperty("discountedPriceInfo")]
        public string DiscountedPriceInfo { get; set; }

        [JsonProperty("hasCollectableCoupon")]
        public bool HasCollectableCoupon { get; set; }

        [JsonProperty("sameDayShipping")]
        public bool SameDayShipping { get; set; }
    }
}
