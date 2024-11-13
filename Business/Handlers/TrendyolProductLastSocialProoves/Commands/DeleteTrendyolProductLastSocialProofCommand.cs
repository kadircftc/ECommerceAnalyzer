
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Business.BusinessAspects;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using MediatR;
using System.Threading;
using System.Threading.Tasks;


namespace Business.Handlers.TrendyolProductLastSocialProoves.Commands
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteTrendyolProductLastSocialProofCommand : IRequest<IResult>
    {
        public int Id { get; set; }

        public class DeleteTrendyolProductLastSocialProofCommandHandler : IRequestHandler<DeleteTrendyolProductLastSocialProofCommand, IResult>
        {
            private readonly ITrendyolProductLastSocialProofRepository _trendyolProductLastSocialProofRepository;
            private readonly IMediator _mediator;

            public DeleteTrendyolProductLastSocialProofCommandHandler(ITrendyolProductLastSocialProofRepository trendyolProductLastSocialProofRepository, IMediator mediator)
            {
                _trendyolProductLastSocialProofRepository = trendyolProductLastSocialProofRepository;
                _mediator = mediator;
            }

            [CacheRemoveAspect("Get")]
            [LogAspect(typeof(FileLogger))]
            [SecuredOperation(Priority = 1)]
            public async Task<IResult> Handle(DeleteTrendyolProductLastSocialProofCommand request, CancellationToken cancellationToken)
            {
                var trendyolProductLastSocialProofToDelete = _trendyolProductLastSocialProofRepository.Get(p => p.Id == request.Id);

                _trendyolProductLastSocialProofRepository.Delete(trendyolProductLastSocialProofToDelete);
                await _trendyolProductLastSocialProofRepository.SaveChangesAsync();
                return new SuccessResult(Messages.Deleted);
            }
        }
    }
}

