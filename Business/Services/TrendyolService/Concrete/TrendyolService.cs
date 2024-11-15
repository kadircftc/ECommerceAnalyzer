using Business.Services.TrendyolService.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Nest;
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
        private readonly ITrendyolProductImagesRepository productImagesRepository;
        private readonly ITrendyolProductTagRepository productTagRepository;

        public TrendyolService(HttpClient client, ITrendyolProductImagesRepository productImagesRepository, ITrendyolProductTagRepository productTagRepository)
        {
            this.client = client;
            this.productImagesRepository = productImagesRepository;
            this.productTagRepository = productTagRepository;
        }

        public async Task<IEnumerable<TrendyolProduct>> GetAll()
        {
            List<TrendyolProduct> pList = new List<TrendyolProduct>();
            int index = 1;

            for (int page = 1; page <= 2; page++)
            {
                string apiUrl = $"https://apigw.trendyol.com/discovery-web-searchgw-service/v2/api/filter/kadin-giyim-x-g1-c82?sst=BEST_SELLER&pi={page}";
                var response = await client.GetStringAsync(apiUrl);

                BaseProductsModel baseModel = JsonConvert.DeserializeObject<BaseProductsModel>(response);

                if (baseModel?.Result.Products != null)
                {
                    foreach (var baseProduct in baseModel.Result.Products)
                    {
                        string reviewsApiDetailedUrl = $"https://apigw.trendyol.com/discovery-web-websfxsocialreviewrating-santral/product-reviews-detailed?sellerId={baseProduct?.MerchantId}&contentId={baseProduct?.Id}&pageSize=20&channelId=1";

                        var reviewsApiDetailedUrlResponse = await client.GetStringAsync(reviewsApiDetailedUrl);

                        ProductRewievsDetailed productReviewsDetailedModel = JsonConvert.DeserializeObject<ProductRewievsDetailed>(reviewsApiDetailedUrlResponse);

                        string socialProofApiUrl = $"https://apigw.trendyol.com/discovery-web-searchgw-service/social-proof?contentIds={baseProduct.Id}&channelId=1";
                        var socialProofApiUrlResponse = await client.GetStringAsync(socialProofApiUrl);
                        var socialProofApiModel = JsonConvert.DeserializeObject<TrendyolSocialProof>(socialProofApiUrlResponse);

                        int favCount = 0;
                        int basketCount = 0;
                        int orderCount = 0;
                        int pageViewCount = 0;

                        if (socialProofApiModel != null && socialProofApiModel.Result != null && socialProofApiModel.Result.ContainsKey((baseProduct.Id).ToString()))
                        {
                            var productData = socialProofApiModel.Result[(baseProduct.Id).ToString()];

                            basketCount = productData.BasketCount?.Count != null ?
                                int.TryParse(productData.BasketCount.Count.Trim(), out int tempBasketCount) ? tempBasketCount : 0 : 0;

                            favCount = productData.FavoriteCount?.Count != null ?
                                int.TryParse(productData.FavoriteCount.Count.Trim(), out int tempFavCount) ? tempFavCount : 0 : 0;

                            orderCount = productData.OrderCountL3D?.Count != null
                                ? int.TryParse(productData.OrderCountL3D.Count.TrimEnd('+').Trim(), out int tempOrderCount)
                            ? tempOrderCount
                        : 0
                            : 0;


                            pageViewCount = productData.PageViewCount?.Count != null ?
                                int.TryParse(productData.PageViewCount.Count.Trim(), out int tempPageViewCount) ? tempPageViewCount : 0 : 0;
                        }

                        var product = new TrendyolProduct
                        {
                            ProductId = baseProduct?.Id ?? 0,
                            CategoryHierarchy = baseProduct?.CategoryHierarchy ?? "",
                            CategoryId = baseProduct?.CategoryId ?? 0,
                            CategoryName = baseProduct?.CategoryName ?? "",
                            FavoriteCount = favCount,
                            PageViewCount = pageViewCount,
                            BasketCount = basketCount,
                            OrderCount = orderCount,
                            MerchantId = baseProduct?.MerchantId ?? 0,
                            CampaignId = baseProduct?.CampaignId ?? 0,
                            ListingId = baseProduct?.ListingId ?? "",
                            SameDayShipping = baseProduct?.SameDayShipping ?? false,
                            ProductUrl = baseProduct?.Url ?? "",
                            ProductName = baseProduct?.Name ?? "",
                            BrandName = baseProduct?.Brand?.Name ?? "",
                            Tax = baseProduct?.Tax ?? 0,
                            AvarageRating = baseProduct?.RatingScore?.AverageRating ?? 0,
                            RatingTotalCount = baseProduct?.RatingScore?.TotalCount ?? 0,
                            ProductGroupId = baseProduct?.ProductGroupId ?? 0,
                            BuyingPrice = baseProduct?.Price?.BuyingPrice ?? 0m,
                            Currency = baseProduct?.Price?.Currency ?? "",
                            DiscountPrice = baseProduct?.Price?.DiscountedPrice ?? 0m,
                            OriginalPrice = baseProduct?.Price?.OriginalPrice ?? 0m,
                            SellingPrice = baseProduct?.Price?.SellingPrice ?? 0m,
                            RushDeliveryDuration = baseProduct?.RushDeliveryDuration ?? 0,
                            FreeCargo = baseProduct?.FreeCargo ?? false,
                            CampaignName = baseProduct?.CampaignName ?? "",
                            CommentCount = productReviewsDetailedModel?.Result?.ContentSummary?.CommentCount ?? 0,
                            WinnerVariant = baseProduct?.WinnerVariant ?? "",
                            PIndex = index,
                            FetchDate = DateTime.Now,
                            PriceLabelName = baseProduct?.Variants?.FirstOrDefault()?.PriceLabels?.FirstOrDefault()?.Name ?? "",
                            PriceLabelValue = baseProduct?.Variants?.FirstOrDefault()?.PriceLabels?.FirstOrDefault()?.Value ?? "",
                            HasBadges = baseProduct?.Badges != null && baseProduct.Badges.Count() > 0,
                            HasCategoryTopRankings = baseProduct?.CategoryTopRankings != null && baseProduct.CategoryTopRankings.Count() > 0,
                            HasPromotions = baseProduct?.Promotions != null && baseProduct.Promotions.Count() > 0,
                            HasCollectableCoupon = baseProduct?.HasCollectableCoupon ?? false,
                            HasPriceLabels = baseProduct?.PriceLabels != null && baseProduct.PriceLabels.Count() > 0,

                            SortType = "BEST_SELLER",
                        };

                        var isThereTrendyolProductImagesRecord = productImagesRepository.Query().Any(u => u.ProductId == product.ProductId);

                        if (isThereTrendyolProductImagesRecord == false)
                        {

                            foreach (string itemImages in baseProduct.Images)
                            {
                                productImagesRepository.Add(new TrendyolProductImages
                                {
                                    ProductId = baseProduct.Id,
                                    ImgUrl = itemImages,
                                    FetchDate = product.FetchDate,
                                });
                            }

                        }

                        foreach (ContentSummaryTag itemTag in productReviewsDetailedModel.Result.ContentSummary.Tags)
                        {
                            productTagRepository.Add(new TrendyolProductTag { MerchantId=baseProduct.MerchantId,FetchDate=DateTime.Now,ProductId=baseProduct.Id,TagCount=itemTag.Count,TagName=itemTag.Name});
                        }

                        pList.Add(product);
                        index++;
                    }
                }
                await productImagesRepository.SaveChangesAsync();
                await productTagRepository.SaveChangesAsync();
            }
            return pList;
        }

    }
}
