
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


namespace Business.Handlers.TrendyolProductBadges.Commands
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteTrendyolProductBadgeCommand : IRequest<IResult>
    {
        public int Id { get; set; }

        public class DeleteTrendyolProductBadgeCommandHandler : IRequestHandler<DeleteTrendyolProductBadgeCommand, IResult>
        {
            private readonly ITrendyolProductBadgeRepository _trendyolProductBadgeRepository;
            private readonly IMediator _mediator;

            public DeleteTrendyolProductBadgeCommandHandler(ITrendyolProductBadgeRepository trendyolProductBadgeRepository, IMediator mediator)
            {
                _trendyolProductBadgeRepository = trendyolProductBadgeRepository;
                _mediator = mediator;
            }

            [CacheRemoveAspect("Get")]
            [LogAspect(typeof(FileLogger))]
            [SecuredOperation(Priority = 1)]
            public async Task<IResult> Handle(DeleteTrendyolProductBadgeCommand request, CancellationToken cancellationToken)
            {
                var trendyolProductBadgeToDelete = _trendyolProductBadgeRepository.Get(p => p.Id == request.Id);

                _trendyolProductBadgeRepository.Delete(trendyolProductBadgeToDelete);
                await _trendyolProductBadgeRepository.SaveChangesAsync();
                return new SuccessResult(Messages.Deleted);
            }
        }
    }
}

