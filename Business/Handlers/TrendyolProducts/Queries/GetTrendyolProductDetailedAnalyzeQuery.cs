using Business.BusinessAspects;
using Core.Aspects.Autofac.Performance;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Aspects.Autofac.Caching;
using Entities.Dtos;

namespace Business.Handlers.TrendyolProducts.Queries
{
    public class GetTrendyolProductDetailedAnalyzeQuery : IRequest<IDataResult<List<TrendyolProductTransferDto>>>
    {
        public class GetTrendyolProductDetailedAnalyzeQueryHandler : IRequestHandler<GetTrendyolProductDetailedAnalyzeQuery, IDataResult<List<TrendyolProductTransferDto>>>
        {
            private readonly ITrendyolProductRepository _trendyolProductRepository;
            private readonly ITrendyolProductImagesRepository _trendyolImageRepository;
            private readonly ITrendyolProductBadgeRepository _trendyolProductBadgeRepository;
            private readonly ITrendyolProductLastSocialProofRepository _trendyolProductLastSocialProofRepository;
            private readonly ITrendyolProductTagRepository _trendyolProductTagRepository;
            private readonly IMediator _mediator;

            public GetTrendyolProductDetailedAnalyzeQueryHandler(ITrendyolProductRepository trendyolProductRepository, ITrendyolProductImagesRepository trendyolImageRepository, ITrendyolProductBadgeRepository trendyolProductBadgeRepository, ITrendyolProductLastSocialProofRepository trendyolProductLastSocialProofRepository, ITrendyolProductTagRepository trendyolProductTagRepository, IMediator mediator)
            {
                _trendyolProductRepository = trendyolProductRepository;
                _trendyolImageRepository = trendyolImageRepository;
                _trendyolProductBadgeRepository = trendyolProductBadgeRepository;
                _trendyolProductLastSocialProofRepository = trendyolProductLastSocialProofRepository;
                _trendyolProductTagRepository = trendyolProductTagRepository;
                _mediator = mediator;
            }

            [PerformanceAspect(5)]
            [CacheAspect(10)]
            [LogAspect(typeof(FileLogger))]
           // [SecuredOperation(Priority = 1)]
            public async Task<IDataResult<List<TrendyolProductTransferDto>>> Handle(GetTrendyolProductDetailedAnalyzeQuery request, CancellationToken cancellationToken)
            {
                var products = await _trendyolProductRepository.GetListAsync();

                var productDtos = new List<TrendyolProductTransferDto>();

                foreach (var product in products)
                {
                    var images = await _trendyolImageRepository.GetListAsync(p=>p.ProductId==product.ProductId);

                    var badges = await _trendyolProductBadgeRepository.GetListAsync(p => p.ProductId == product.ProductId);
                    var groupedBadges = badges
                        .GroupBy(badge => badge.FetchDate.Date.ToString("yyyy-MM-dd")) 
                        .ToDictionary(
                            group => group.Key,
                            group => group.ToList()
                        );

                    var lastSocial = await _trendyolProductLastSocialProofRepository.GetListAsync(p => p.ProductId == product.ProductId);
                    var groupedLastSocial = lastSocial
                        .GroupBy(lastSocial => lastSocial.FetchDate.Date.ToString("yyyy-MM-dd")) 
                        .ToDictionary(
                            group => group.Key,
                            group => group.ToList()
                        );
                    var tags = await _trendyolProductTagRepository.GetListAsync(p => p.ProductId == product.ProductId);
                    var groupedTags = tags
                        .GroupBy(tag => tag.FetchDate.ToString("yyyy-MM-dd"))
                         .ToDictionary(
                            group => group.Key,
                            group => group.ToList()
                        );
                    productDtos.Add(new TrendyolProductTransferDto
                    {
                        ProductId = product.ProductId,
                        CategoryHierarchy = product.CategoryHierarchy,
                        CategoryId = product.CategoryId,
                        CategoryName = product.CategoryName,
                        FavoriteCount = product.FavoriteCount,
                        OrderCount = product.OrderCount,
                        PageViewCount = product.PageViewCount,
                        BasketCount = product.BasketCount,
                        MerchantId = product.MerchantId,
                        CampaignId = product.CampaignId,
                        ListingId = product.ListingId,
                        SameDayShipping = product.SameDayShipping,
                        PriceLabelName = product.PriceLabelName,
                        PriceLabelValue = product.PriceLabelValue,
                        ProductUrl = product.ProductUrl,
                        ProductName = product.ProductName,
                        BrandName = product.BrandName,
                        Tax = product.Tax,
                        AvarageRating = product.AvarageRating,
                        RatingTotalCount = product.RatingTotalCount,
                        ProductGroupId = product.ProductGroupId,
                        BuyingPrice = product.BuyingPrice,
                        Currency = product.Currency,
                        DiscountPrice = product.DiscountPrice,
                        OriginalPrice = product.OriginalPrice,
                        SellingPrice = product.SellingPrice,
                        RushDeliveryDuration = product.RushDeliveryDuration,
                        CommentCount = product.CommentCount,
                        FreeCargo = product.FreeCargo,
                        CampaignName = product.CampaignName,
                        WinnerVariant = product.WinnerVariant,
                        PIndex = product.PIndex,
                        HasCategoryTopRankings = product.HasCategoryTopRankings,
                        HasPromotions = product.HasPromotions,
                        SortType = product.SortType,
                        HasPriceLabels = product.HasPriceLabels,
                        HasCollectableCoupon = product.HasCollectableCoupon,
                        HasBadges = product.HasBadges,
                        Images = images.Select(img => img.ImgUrl).ToList(),
                        Badges = groupedBadges.Select(g => new Dictionary<string, List<TrendyolProductBadge>>
                        {
                            { g.Key, g.Value }
                        }).ToList() ,
                        LastSocialProof = groupedLastSocial.Select(g => new Dictionary<string, List<TrendyolProductLastSocialProof>>
                        {
                            { g.Key, g.Value }
                        }).ToList(),
                      Tags = groupedTags.Select(g => new Dictionary<string, List<TrendyolProductTag>>
                        {
                            { g.Key, g.Value }
                        }).ToList(),
                    });
                }

                return new SuccessDataResult<List<TrendyolProductTransferDto>>(productDtos);
            }
        }
    }
}
