
using Business.BusinessAspects;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;


namespace Business.Handlers.TrendyolProductLastSocialProoves.Queries
{
    public class GetTrendyolProductLastSocialProofQuery : IRequest<IDataResult<TrendyolProductLastSocialProof>>
    {
        public int Id { get; set; }

        public class GetTrendyolProductLastSocialProofQueryHandler : IRequestHandler<GetTrendyolProductLastSocialProofQuery, IDataResult<TrendyolProductLastSocialProof>>
        {
            private readonly ITrendyolProductLastSocialProofRepository _trendyolProductLastSocialProofRepository;
            private readonly IMediator _mediator;

            public GetTrendyolProductLastSocialProofQueryHandler(ITrendyolProductLastSocialProofRepository trendyolProductLastSocialProofRepository, IMediator mediator)
            {
                _trendyolProductLastSocialProofRepository = trendyolProductLastSocialProofRepository;
                _mediator = mediator;
            }
            [LogAspect(typeof(FileLogger))]
            [SecuredOperation(Priority = 1)]
            public async Task<IDataResult<TrendyolProductLastSocialProof>> Handle(GetTrendyolProductLastSocialProofQuery request, CancellationToken cancellationToken)
            {
                var trendyolProductLastSocialProof = await _trendyolProductLastSocialProofRepository.GetAsync(p => p.Id == request.Id);
                return new SuccessDataResult<TrendyolProductLastSocialProof>(trendyolProductLastSocialProof);
            }
        }
    }
}
