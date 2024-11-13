
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
using Business.Handlers.TrendyolProductLastSocialProoves.ValidationRules;

namespace Business.Handlers.TrendyolProductLastSocialProoves.Commands
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateTrendyolProductLastSocialProofCommand : IRequest<IResult>
    {

        public System.DateTime FetchDate { get; set; }
        public int ProductId { get; set; }
        public int FavoriteCount { get; set; }
        public int OrderCount { get; set; }
        public int BasketCount { get; set; }
        public int PageViewCount { get; set; }


        public class CreateTrendyolProductLastSocialProofCommandHandler : IRequestHandler<CreateTrendyolProductLastSocialProofCommand, IResult>
        {
            private readonly ITrendyolProductLastSocialProofRepository _trendyolProductLastSocialProofRepository;
            private readonly IMediator _mediator;
            public CreateTrendyolProductLastSocialProofCommandHandler(ITrendyolProductLastSocialProofRepository trendyolProductLastSocialProofRepository, IMediator mediator)
            {
                _trendyolProductLastSocialProofRepository = trendyolProductLastSocialProofRepository;
                _mediator = mediator;
            }

            [ValidationAspect(typeof(CreateTrendyolProductLastSocialProofValidator), Priority = 1)]
            [CacheRemoveAspect("Get")]
            [LogAspect(typeof(FileLogger))]
            [SecuredOperation(Priority = 1)]
            public async Task<IResult> Handle(CreateTrendyolProductLastSocialProofCommand request, CancellationToken cancellationToken)
            {
                var isThereTrendyolProductLastSocialProofRecord = _trendyolProductLastSocialProofRepository.Query().Any(u => u.FetchDate == request.FetchDate);

                if (isThereTrendyolProductLastSocialProofRecord == true)
                    return new ErrorResult(Messages.NameAlreadyExist);

                var addedTrendyolProductLastSocialProof = new TrendyolProductLastSocialProof
                {
                    FetchDate = System.DateTime.Now,
                    ProductId = request.ProductId,
                    FavoriteCount = request.FavoriteCount,
                    OrderCount = request.OrderCount,
                    BasketCount = request.BasketCount,
                    PageViewCount = request.PageViewCount,
                    
                };

                _trendyolProductLastSocialProofRepository.Add(addedTrendyolProductLastSocialProof);
                await _trendyolProductLastSocialProofRepository.SaveChangesAsync();
                return new SuccessResult(Messages.Added);
            }
        }
    }
}