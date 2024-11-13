
using Business.Constants;
using Business.BusinessAspects;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Core.Aspects.Autofac.Validation;
using Business.Handlers.TrendyolProducts.ValidationRules;


namespace Business.Handlers.TrendyolProducts.Commands
{


    public class UpdateTrendyolProductCommand : IRequest<IResult>
    {
        public int Id { get; set; }
        public System.DateTime FetchDate { get; set; }
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

        public class UpdateTrendyolProductCommandHandler : IRequestHandler<UpdateTrendyolProductCommand, IResult>
        {
            private readonly ITrendyolProductRepository _trendyolProductRepository;
            private readonly IMediator _mediator;

            public UpdateTrendyolProductCommandHandler(ITrendyolProductRepository trendyolProductRepository, IMediator mediator)
            {
                _trendyolProductRepository = trendyolProductRepository;
                _mediator = mediator;
            }

            [ValidationAspect(typeof(UpdateTrendyolProductValidator), Priority = 1)]
            [CacheRemoveAspect("Get")]
            [LogAspect(typeof(FileLogger))]
            [SecuredOperation(Priority = 1)]
            public async Task<IResult> Handle(UpdateTrendyolProductCommand request, CancellationToken cancellationToken)
            {
                var isThereTrendyolProductRecord = await _trendyolProductRepository.GetAsync(u => u.Id == request.Id);


                isThereTrendyolProductRecord.FetchDate = request.FetchDate;
                isThereTrendyolProductRecord.ProductId = request.ProductId;
                isThereTrendyolProductRecord.CategoryHierarchy = request.CategoryHierarchy;
                isThereTrendyolProductRecord.CategoryId = request.CategoryId;
                isThereTrendyolProductRecord.CategoryName = request.CategoryName;
                isThereTrendyolProductRecord.FavoriteCount = request.FavoriteCount;
                isThereTrendyolProductRecord.OrderCount = request.OrderCount;
                isThereTrendyolProductRecord.PageViewCount = request.PageViewCount;
                isThereTrendyolProductRecord.BasketCount = request.BasketCount;
                isThereTrendyolProductRecord.MerchantId = request.MerchantId;
                isThereTrendyolProductRecord.CampaignId = request.CampaignId;
                isThereTrendyolProductRecord.ListingId = request.ListingId;
                isThereTrendyolProductRecord.SameDayShipping = request.SameDayShipping;
                isThereTrendyolProductRecord.PriceLabelName = request.PriceLabelName;
                isThereTrendyolProductRecord.PriceLabelValue = request.PriceLabelValue;
                isThereTrendyolProductRecord.ProductUrl = request.ProductUrl;
                isThereTrendyolProductRecord.ProductName = request.ProductName;
                isThereTrendyolProductRecord.BrandName = request.BrandName;
                isThereTrendyolProductRecord.Tax = request.Tax;
                isThereTrendyolProductRecord.AvarageRating = request.AvarageRating;
                isThereTrendyolProductRecord.RatingTotalCount = request.RatingTotalCount;
                isThereTrendyolProductRecord.ProductGroupId = request.ProductGroupId;
                isThereTrendyolProductRecord.BuyingPrice = request.BuyingPrice;
                isThereTrendyolProductRecord.Currency = request.Currency;
                isThereTrendyolProductRecord.DiscountPrice = request.DiscountPrice;
                isThereTrendyolProductRecord.OriginalPrice = request.OriginalPrice;
                isThereTrendyolProductRecord.SellingPrice = request.SellingPrice;
                isThereTrendyolProductRecord.RushDeliveryDuration = request.RushDeliveryDuration;
                isThereTrendyolProductRecord.CommentCount = request.CommentCount;
                isThereTrendyolProductRecord.FreeCargo = request.FreeCargo;
                isThereTrendyolProductRecord.CampaignName = request.CampaignName;
                isThereTrendyolProductRecord.WinnerVariant = request.WinnerVariant;
                isThereTrendyolProductRecord.PIndex = request.PIndex;


                _trendyolProductRepository.Update(isThereTrendyolProductRecord);
                await _trendyolProductRepository.SaveChangesAsync();
                return new SuccessResult(Messages.Updated);
            }
        }
    }
}

