
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
using Business.Handlers.TrendyolProductLastSocialProoves.ValidationRules;


namespace Business.Handlers.TrendyolProductLastSocialProoves.Commands
{


    public class UpdateTrendyolProductLastSocialProofCommand : IRequest<IResult>
    {
        public int Id { get; set; }
        public System.DateTime FetchDate { get; set; }
        public int ProductId { get; set; }
        public int FavoriteCount { get; set; }
        public int OrderCount { get; set; }
        public int BasketCount { get; set; }
        public int PageViewCount { get; set; }

        public class UpdateTrendyolProductLastSocialProofCommandHandler : IRequestHandler<UpdateTrendyolProductLastSocialProofCommand, IResult>
        {
            private readonly ITrendyolProductLastSocialProofRepository _trendyolProductLastSocialProofRepository;
            private readonly IMediator _mediator;

            public UpdateTrendyolProductLastSocialProofCommandHandler(ITrendyolProductLastSocialProofRepository trendyolProductLastSocialProofRepository, IMediator mediator)
            {
                _trendyolProductLastSocialProofRepository = trendyolProductLastSocialProofRepository;
                _mediator = mediator;
            }

            [ValidationAspect(typeof(UpdateTrendyolProductLastSocialProofValidator), Priority = 1)]
            [CacheRemoveAspect("Get")]
            [LogAspect(typeof(FileLogger))]
            [SecuredOperation(Priority = 1)]
            public async Task<IResult> Handle(UpdateTrendyolProductLastSocialProofCommand request, CancellationToken cancellationToken)
            {
                var isThereTrendyolProductLastSocialProofRecord = await _trendyolProductLastSocialProofRepository.GetAsync(u => u.Id == request.Id);


                isThereTrendyolProductLastSocialProofRecord.FetchDate = request.FetchDate;
                isThereTrendyolProductLastSocialProofRecord.ProductId = request.ProductId;
                isThereTrendyolProductLastSocialProofRecord.FavoriteCount = request.FavoriteCount;
                isThereTrendyolProductLastSocialProofRecord.OrderCount = request.OrderCount;
                isThereTrendyolProductLastSocialProofRecord.BasketCount = request.BasketCount;
                isThereTrendyolProductLastSocialProofRecord.PageViewCount = request.PageViewCount;


                _trendyolProductLastSocialProofRepository.Update(isThereTrendyolProductLastSocialProofRecord);
                await _trendyolProductLastSocialProofRepository.SaveChangesAsync();
                return new SuccessResult(Messages.Updated);
            }
        }
    }
}

