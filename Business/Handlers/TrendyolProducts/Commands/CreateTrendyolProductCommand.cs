
using Business.BusinessAspects;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Business.Handlers.TrendyolProducts.ValidationRules;

namespace Business.Handlers.TrendyolProducts.Commands
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateTrendyolProductCommand : IRequest<IResult>
    {

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


        public class CreateTrendyolProductCommandHandler : IRequestHandler<CreateTrendyolProductCommand, IResult>
        {
            private readonly ITrendyolProductRepository _trendyolProductRepository;
            private readonly IMediator _mediator;
            public CreateTrendyolProductCommandHandler(ITrendyolProductRepository trendyolProductRepository, IMediator mediator)
            {
                _trendyolProductRepository = trendyolProductRepository;
                _mediator = mediator;
            }

            [ValidationAspect(typeof(CreateTrendyolProductValidator), Priority = 1)]
            [CacheRemoveAspect("Get")]
            [LogAspect(typeof(FileLogger))]
            [SecuredOperation(Priority = 1)]
            public async Task<IResult> Handle(CreateTrendyolProductCommand request, CancellationToken cancellationToken)
            {
                var isThereTrendyolProductRecord = _trendyolProductRepository.Query().Any(u => u.ProductId == request.ProductId);

                if (isThereTrendyolProductRecord == true)
                    return new ErrorResult(Messages.NameAlreadyExist);

                var addedTrendyolProduct = new TrendyolProduct
                {
                    FetchDate = request.FetchDate,
                    ProductId = request.ProductId,
                    CategoryHierarchy = request.CategoryHierarchy,
                    CategoryId = request.CategoryId,
                    CategoryName = request.CategoryName,
                    FavoriteCount = request.FavoriteCount,
                    OrderCount = request.OrderCount,
                    PageViewCount = request.PageViewCount,
                    BasketCount = request.BasketCount,
                    MerchantId = request.MerchantId,
                    CampaignId = request.CampaignId,
                    ListingId = request.ListingId,
                    SameDayShipping = request.SameDayShipping,
                    PriceLabelName = request.PriceLabelName,
                    PriceLabelValue = request.PriceLabelValue,
                    ProductUrl = request.ProductUrl,
                    ProductName = request.ProductName,
                    BrandName = request.BrandName,
                    Tax = request.Tax,
                    AvarageRating = request.AvarageRating,
                    RatingTotalCount = request.RatingTotalCount,
                    ProductGroupId = request.ProductGroupId,
                    BuyingPrice = request.BuyingPrice,
                    Currency = request.Currency,
                    DiscountPrice = request.DiscountPrice,
                    OriginalPrice = request.OriginalPrice,
                    SellingPrice = request.SellingPrice,
                    RushDeliveryDuration = request.RushDeliveryDuration,
                    CommentCount = request.CommentCount,
                    FreeCargo = request.FreeCargo,
                    CampaignName = request.CampaignName,
                    WinnerVariant = request.WinnerVariant,
                    PIndex = request.PIndex,

                };

                _trendyolProductRepository.Add(addedTrendyolProduct);
                await _trendyolProductRepository.SaveChangesAsync();
                return new SuccessResult(Messages.Added);
            }
        }
    }
}