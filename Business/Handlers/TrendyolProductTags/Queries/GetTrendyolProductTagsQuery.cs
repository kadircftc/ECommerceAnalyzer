
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

namespace Business.Handlers.TrendyolProductTags.Queries
{

    public class GetTrendyolProductTagsQuery : IRequest<IDataResult<IEnumerable<TrendyolProductTag>>>
    {
        public class GetTrendyolProductTagsQueryHandler : IRequestHandler<GetTrendyolProductTagsQuery, IDataResult<IEnumerable<TrendyolProductTag>>>
        {
            private readonly ITrendyolProductTagRepository _trendyolProductTagRepository;
            private readonly IMediator _mediator;

            public GetTrendyolProductTagsQueryHandler(ITrendyolProductTagRepository trendyolProductTagRepository, IMediator mediator)
            {
                _trendyolProductTagRepository = trendyolProductTagRepository;
                _mediator = mediator;
            }

            [PerformanceAspect(5)]
            [CacheAspect(10)]
            [LogAspect(typeof(FileLogger))]
            [SecuredOperation(Priority = 1)]
            public async Task<IDataResult<IEnumerable<TrendyolProductTag>>> Handle(GetTrendyolProductTagsQuery request, CancellationToken cancellationToken)
            {
                return new SuccessDataResult<IEnumerable<TrendyolProductTag>>(await _trendyolProductTagRepository.GetListAsync());
            }
        }
    }
}