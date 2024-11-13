
using Business.BusinessAspects;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;


namespace Business.Handlers.TrendyolProductTags.Queries
{
    public class GetTrendyolProductTagQuery : IRequest<IDataResult<TrendyolProductTag>>
    {
        public int Id { get; set; }

        public class GetTrendyolProductTagQueryHandler : IRequestHandler<GetTrendyolProductTagQuery, IDataResult<TrendyolProductTag>>
        {
            private readonly ITrendyolProductTagRepository _trendyolProductTagRepository;
            private readonly IMediator _mediator;

            public GetTrendyolProductTagQueryHandler(ITrendyolProductTagRepository trendyolProductTagRepository, IMediator mediator)
            {
                _trendyolProductTagRepository = trendyolProductTagRepository;
                _mediator = mediator;
            }
            [LogAspect(typeof(FileLogger))]
            [SecuredOperation(Priority = 1)]
            public async Task<IDataResult<TrendyolProductTag>> Handle(GetTrendyolProductTagQuery request, CancellationToken cancellationToken)
            {
                var trendyolProductTag = await _trendyolProductTagRepository.GetAsync(p => p.Id == request.Id);
                return new SuccessDataResult<TrendyolProductTag>(trendyolProductTag);
            }
        }
    }
}
