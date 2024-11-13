using Business.Services.TrendyolService.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.TrendyolService.Concrete
{
    public class TrendyolService : ITrendyolService
    {
        private readonly HttpClient client;

        public TrendyolService(HttpClient httpClient)
        {
            client = httpClient;
        }

        public async Task<IEnumerable<TrendyolProduct>> GetAll()
        {
            List<TrendyolProduct> pList = new List<TrendyolProduct>();
            int index = 1;

            for (int page = 1; page <= 10; page++)
            {
                string apiUrl = $"https://apigw.trendyol.com/discovery-web-searchgw-service/v2/api/filter/kadin-taki-mucevher-x-g1-c28?pi={page}&sst=BEST_SELLER";
                var response = await client.GetStringAsync(apiUrl);

                BaseProductsModel baseModel = JsonConvert.DeserializeObject<BaseProductsModel>(response);

                if (baseModel?.Result.Products != null)
                {
                    foreach (var baseProduct in baseModel.Result.Products)
                    {
                        string reviewsApiDetailedUrl = $"https://apigw.trendyol.com/discovery-web-websfxsocialreviewrating-santral/product-reviews-detailed?sellerId={baseProduct?.MerchantId}&contentId={baseProduct?.Id}&pageSize=20&channelId=1";

                        var reviewsApiDetailedUrlResponse = await client.GetStringAsync(reviewsApiDetailedUrl);

                        ProductRewievsDetailed productReviewsDetailedModel = JsonConvert.DeserializeObject<ProductRewievsDetailed>(reviewsApiDetailedUrlResponse);
                        var product = new TrendyolProduct
                        {
                            ProductId = baseProduct?.Id ?? 0,
                            CategoryHierarchy = baseProduct?.CategoryHierarchy ?? "",
                            CategoryId = baseProduct?.CategoryId ?? 0,
                            CategoryName = baseProduct.CategoryName ?? "",
                            FavoriteCount = baseProduct.SocialProof.FavoriteCount?.Count ?? 0,
                            OrderCount = baseProduct.SocialProof.OrderCount?.Count ?? 0,
                            PageViewCount = baseProduct.SocialProof.PageViewCount?.Count ?? 0,
                            BasketCount = baseProduct.SocialProof.BasketCount?.Count ?? 0,
                            MerchantId = baseProduct?.MerchantId ?? 0,
                            CampaignId = baseProduct?.CampaignId ?? 0,
                            ListingId = baseProduct?.ListingId ?? "",
                            SameDayShipping = baseProduct?.SameDayShipping ?? false,
                            ProductUrl = baseProduct?.Url ?? "",
                            ProductName = baseProduct?.Name ?? "",
                            BrandName = baseProduct.Brand?.Name ?? "",
                            Tax = baseProduct?.Tax ?? 0,
                            AvarageRating = baseProduct?.RatingScore?.AverageRating ?? 0,
                            RatingTotalCount = baseProduct?.RatingScore?.TotalCount ?? 0,
                            ProductGroupId = baseProduct?.ProductGroupId ?? 0,
                            BuyingPrice = baseProduct.Price?.BuyingPrice ?? 0m,
                            Currency = baseProduct.Price?.Currency ?? "",
                            DiscountPrice = baseProduct.Price?.DiscountedPrice ?? 0m,
                            OriginalPrice = baseProduct.Price?.OriginalPrice ?? 0m,
                            SellingPrice = baseProduct.Price?.SellingPrice ?? 0m,
                            RushDeliveryDuration = baseProduct?.RushDeliveryDuration ?? 0,
                            FreeCargo = baseProduct?.FreeCargo ?? false,
                            CampaignName = baseProduct?.CampaignName ?? "",
                            CommentCount = productReviewsDetailedModel?.Result.ContentSummary.CommentCount ?? 0,
                            WinnerVariant = baseProduct.WinnerVariant ?? "",
                            PIndex = index,
                            FetchDate=DateTime.Now,
                            PriceLabelName = baseProduct.Variants[0].PriceLabels[0].Name,
                            PriceLabelValue = baseProduct.Variants[0].PriceLabels[0].Value,
                        };
                        
                        pList.Add(product);
                        index++;
                    }
                }
            }
            return pList;
        }
    }
}
