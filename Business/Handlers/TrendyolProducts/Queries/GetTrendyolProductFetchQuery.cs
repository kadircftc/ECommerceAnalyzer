using Business.BusinessAspects;
using Business.Constants;
using Business.Services.TrendyolService.Abstract;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Performance;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.TrendyolProducts.Queries
{
    public class GetTrendyolProductFetchQuery:IRequest<IDataResult<IEnumerable<TrendyolProduct>>>
    {
        public class GetTrendyolProductFetchQueryHandler : IRequestHandler<GetTrendyolProductFetchQuery, IDataResult<IEnumerable<TrendyolProduct>>>
        {
            private readonly ITrendyolService _trendyolService;
            private readonly ITrendyolProductLastSocialProofRepository _trendyolSocialService;
            private readonly ITrendyolProductRepository _trendyolRepository;
            private readonly ITrendyolProductImagesRepository _trendyolImagesRepository;
            private readonly IMediator _mediator;

            public GetTrendyolProductFetchQueryHandler(ITrendyolService trendyolService, ITrendyolProductLastSocialProofRepository trendyolSocialService, ITrendyolProductRepository trendyolRepository, ITrendyolProductImagesRepository trendyolImagesRepository, IMediator mediator)
            {
                _trendyolService = trendyolService;
                _trendyolSocialService = trendyolSocialService;
                _trendyolRepository = trendyolRepository;
                _trendyolImagesRepository = trendyolImagesRepository;
                _mediator = mediator;
            }

            [PerformanceAspect(5)]
            //[SecuredOperation(Priority = 1)]
            public async Task<IDataResult<IEnumerable<TrendyolProduct>>> Handle(GetTrendyolProductFetchQuery request, CancellationToken cancellationToken)
            {
                int ayniProductId = 0;
                IEnumerable<TrendyolProduct> result = await _trendyolService.GetAll() ;
               foreach (TrendyolProduct item in result)
                {
                    var isThereTrendyolProductRecord = _trendyolRepository.Query().Any(u => u.ProductId == item.ProductId);

                    if (isThereTrendyolProductRecord == false)
                    {
                        _trendyolRepository.Add(item);
                    }
                    else
                    {
                        _trendyolSocialService.Add(new TrendyolProductLastSocialProof
                        {
                            BasketCount = item.BasketCount,
                            PIndex = item.PIndex,
                            ProductId = item.ProductId,
                            OrderCount = item.OrderCount,
                            FavoriteCount = item.FavoriteCount,
                            PageViewCount = item.PageViewCount, 
                            FetchDate=item.FetchDate,
                            HasPriceLabels=item.HasPriceLabels,
                            SortType=item.SortType,
                            AvarageRating=item.AvarageRating,
                            BuyingPrice=item.BuyingPrice,   
                            CommentCount=item.CommentCount,
                            DiscountPrice=item.DiscountPrice,
                            FreeCargo = item.FreeCargo,
                            HasCategoryTopRankings=item.HasCategoryTopRankings,
                            HasCollectableCoupon=item.HasCollectableCoupon,
                            HasPromotions=item.HasPromotions,
                            OriginalPrice=item.OriginalPrice,
                            RatingTotalCount=item.RatingTotalCount,
                            SellingPrice =item.SellingPrice,
                            Tax = item.Tax
                        });

                        ayniProductId++;
                    }
                }
              await _trendyolRepository.SaveChangesAsync() ;
              await _trendyolSocialService.SaveChangesAsync();
                return new SuccessDataResult<IEnumerable<TrendyolProduct>>(result,"Same Product Count->"+ayniProductId.ToString());
            }
        }
    }
}
