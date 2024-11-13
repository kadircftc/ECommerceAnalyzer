
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

namespace Business.Handlers.TrendyolProductImageses.Queries
{

    public class GetTrendyolProductImagesesQuery : IRequest<IDataResult<IEnumerable<TrendyolProductImages>>>
    {
        public class GetTrendyolProductImagesesQueryHandler : IRequestHandler<GetTrendyolProductImagesesQuery, IDataResult<IEnumerable<TrendyolProductImages>>>
        {
            private readonly ITrendyolProductImagesRepository _trendyolProductImagesRepository;
            private readonly IMediator _mediator;

            public GetTrendyolProductImagesesQueryHandler(ITrendyolProductImagesRepository trendyolProductImagesRepository, IMediator mediator)
            {
                _trendyolProductImagesRepository = trendyolProductImagesRepository;
                _mediator = mediator;
            }

            [PerformanceAspect(5)]
            [CacheAspect(10)]
            [LogAspect(typeof(FileLogger))]
            [SecuredOperation(Priority = 1)]
            public async Task<IDataResult<IEnumerable<TrendyolProductImages>>> Handle(GetTrendyolProductImagesesQuery request, CancellationToken cancellationToken)
            {
                return new SuccessDataResult<IEnumerable<TrendyolProductImages>>(await _trendyolProductImagesRepository.GetListAsync());
            }
        }
    }
}