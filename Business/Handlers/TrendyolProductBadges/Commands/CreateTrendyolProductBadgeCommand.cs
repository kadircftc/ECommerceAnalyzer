
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
using Business.Handlers.TrendyolProductBadges.ValidationRules;

namespace Business.Handlers.TrendyolProductBadges.Commands
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateTrendyolProductBadgeCommand : IRequest<IResult>
    {

        public System.DateTime FetchDate { get; set; }
        public int ProductId { get; set; }
        public int MerchantId { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }


        public class CreateTrendyolProductBadgeCommandHandler : IRequestHandler<CreateTrendyolProductBadgeCommand, IResult>
        {
            private readonly ITrendyolProductBadgeRepository _trendyolProductBadgeRepository;
            private readonly IMediator _mediator;
            public CreateTrendyolProductBadgeCommandHandler(ITrendyolProductBadgeRepository trendyolProductBadgeRepository, IMediator mediator)
            {
                _trendyolProductBadgeRepository = trendyolProductBadgeRepository;
                _mediator = mediator;
            }

            [ValidationAspect(typeof(CreateTrendyolProductBadgeValidator), Priority = 1)]
            [CacheRemoveAspect("Get")]
            [LogAspect(typeof(FileLogger))]
            [SecuredOperation(Priority = 1)]
            public async Task<IResult> Handle(CreateTrendyolProductBadgeCommand request, CancellationToken cancellationToken)
            {
                var isThereTrendyolProductBadgeRecord = _trendyolProductBadgeRepository.Query().Any(u => u.FetchDate == request.FetchDate);

                if (isThereTrendyolProductBadgeRecord == true)
                    return new ErrorResult(Messages.NameAlreadyExist);

                var addedTrendyolProductBadge = new TrendyolProductBadge
                {
                    FetchDate = request.FetchDate,
                    ProductId = request.ProductId,
                    MerchantId = request.MerchantId,
                    Title = request.Title,
                    Type = request.Type,

                };

                _trendyolProductBadgeRepository.Add(addedTrendyolProductBadge);
                await _trendyolProductBadgeRepository.SaveChangesAsync();
                return new SuccessResult(Messages.Added);
            }
        }
    }
}