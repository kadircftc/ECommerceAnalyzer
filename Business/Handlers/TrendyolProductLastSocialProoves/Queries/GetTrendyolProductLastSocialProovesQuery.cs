
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

namespace Business.Handlers.TrendyolProductLastSocialProoves.Queries
{

    public class GetTrendyolProductLastSocialProovesQuery : IRequest<IDataResult<IEnumerable<TrendyolProductLastSocialProof>>>
    {
        public class GetTrendyolProductLastSocialProovesQueryHandler : IRequestHandler<GetTrendyolProductLastSocialProovesQuery, IDataResult<IEnumerable<TrendyolProductLastSocialProof>>>
        {
            private readonly ITrendyolProductLastSocialProofRepository _trendyolProductLastSocialProofRepository;
            private readonly IMediator _mediator;

            public GetTrendyolProductLastSocialProovesQueryHandler(ITrendyolProductLastSocialProofRepository trendyolProductLastSocialProofRepository, IMediator mediator)
            {
                _trendyolProductLastSocialProofRepository = trendyolProductLastSocialProofRepository;
                _mediator = mediator;
            }

            [PerformanceAspect(5)]
            [CacheAspect(10)]
            [LogAspect(typeof(FileLogger))]
            [SecuredOperation(Priority = 1)]
            public async Task<IDataResult<IEnumerable<TrendyolProductLastSocialProof>>> Handle(GetTrendyolProductLastSocialProovesQuery request, CancellationToken cancellationToken)
            {
                return new SuccessDataResult<IEnumerable<TrendyolProductLastSocialProof>>(await _trendyolProductLastSocialProofRepository.GetListAsync());
            }
        }
    }
}