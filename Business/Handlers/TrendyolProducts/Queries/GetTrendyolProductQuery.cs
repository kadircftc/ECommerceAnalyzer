
using Business.BusinessAspects;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;


namespace Business.Handlers.TrendyolProducts.Queries
{
    public class GetTrendyolProductQuery : IRequest<IDataResult<TrendyolProduct>>
    {
        public int Id { get; set; }

        public class GetTrendyolProductQueryHandler : IRequestHandler<GetTrendyolProductQuery, IDataResult<TrendyolProduct>>
        {
            private readonly ITrendyolProductRepository _trendyolProductRepository;
            private readonly IMediator _mediator;

            public GetTrendyolProductQueryHandler(ITrendyolProductRepository trendyolProductRepository, IMediator mediator)
            {
                _trendyolProductRepository = trendyolProductRepository;
                _mediator = mediator;
            }
            [LogAspect(typeof(FileLogger))]
            [SecuredOperation(Priority = 1)]
            public async Task<IDataResult<TrendyolProduct>> Handle(GetTrendyolProductQuery request, CancellationToken cancellationToken)
            {
                var trendyolProduct = await _trendyolProductRepository.GetAsync(p => p.Id == request.Id);
                return new SuccessDataResult<TrendyolProduct>(trendyolProduct);
            }
        }
    }
}
