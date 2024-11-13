
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

namespace Business.Handlers.TrendyolProducts.Queries
{

    public class GetTrendyolProductsQuery : IRequest<IDataResult<IEnumerable<TrendyolProduct>>>
    {
        public class GetTrendyolProductsQueryHandler : IRequestHandler<GetTrendyolProductsQuery, IDataResult<IEnumerable<TrendyolProduct>>>
        {
            private readonly ITrendyolProductRepository _trendyolProductRepository;
            private readonly IMediator _mediator;

            public GetTrendyolProductsQueryHandler(ITrendyolProductRepository trendyolProductRepository, IMediator mediator)
            {
                _trendyolProductRepository = trendyolProductRepository;
                _mediator = mediator;
            }

            [PerformanceAspect(5)]
            [CacheAspect(10)]
            [LogAspect(typeof(FileLogger))]
            [SecuredOperation(Priority = 1)]
            public async Task<IDataResult<IEnumerable<TrendyolProduct>>> Handle(GetTrendyolProductsQuery request, CancellationToken cancellationToken)
            {
                return new SuccessDataResult<IEnumerable<TrendyolProduct>>(await _trendyolProductRepository.GetListAsync());
            }
        }
    }
}