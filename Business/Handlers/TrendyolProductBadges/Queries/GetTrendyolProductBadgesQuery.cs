
using Business.BusinessAspects;
using Core.Aspects.Autofac.Performance;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Aspects.Autofac.Caching;

namespace Business.Handlers.TrendyolProductBadges.Queries
{

    public class GetTrendyolProductBadgesQuery : IRequest<IDataResult<IEnumerable<TrendyolProductBadge>>>
    {
        public class GetTrendyolProductBadgesQueryHandler : IRequestHandler<GetTrendyolProductBadgesQuery, IDataResult<IEnumerable<TrendyolProductBadge>>>
        {
            private readonly ITrendyolProductBadgeRepository _trendyolProductBadgeRepository;
            private readonly IMediator _mediator;

            public GetTrendyolProductBadgesQueryHandler(ITrendyolProductBadgeRepository trendyolProductBadgeRepository, IMediator mediator)
            {
                _trendyolProductBadgeRepository = trendyolProductBadgeRepository;
                _mediator = mediator;
            }

            [PerformanceAspect(5)]
            [CacheAspect(10)]
            [LogAspect(typeof(FileLogger))]
            [SecuredOperation(Priority = 1)]
            public async Task<IDataResult<IEnumerable<TrendyolProductBadge>>> Handle(GetTrendyolProductBadgesQuery request, CancellationToken cancellationToken)
            {
                return new SuccessDataResult<IEnumerable<TrendyolProductBadge>>(await _trendyolProductBadgeRepository.GetListAsync());
            }
        }
    }
}