
using Business.BusinessAspects;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;


namespace Business.Handlers.TrendyolProductBadges.Queries
{
    public class GetTrendyolProductBadgeQuery : IRequest<IDataResult<TrendyolProductBadge>>
    {
        public int Id { get; set; }

        public class GetTrendyolProductBadgeQueryHandler : IRequestHandler<GetTrendyolProductBadgeQuery, IDataResult<TrendyolProductBadge>>
        {
            private readonly ITrendyolProductBadgeRepository _trendyolProductBadgeRepository;
            private readonly IMediator _mediator;

            public GetTrendyolProductBadgeQueryHandler(ITrendyolProductBadgeRepository trendyolProductBadgeRepository, IMediator mediator)
            {
                _trendyolProductBadgeRepository = trendyolProductBadgeRepository;
                _mediator = mediator;
            }
            [LogAspect(typeof(FileLogger))]
            [SecuredOperation(Priority = 1)]
            public async Task<IDataResult<TrendyolProductBadge>> Handle(GetTrendyolProductBadgeQuery request, CancellationToken cancellationToken)
            {
                var trendyolProductBadge = await _trendyolProductBadgeRepository.GetAsync(p => p.Id == request.Id);
                return new SuccessDataResult<TrendyolProductBadge>(trendyolProductBadge);
            }
        }
    }
}
