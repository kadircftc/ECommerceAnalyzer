
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


namespace Business.Handlers.TrendyolProductTags.Commands
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteTrendyolProductTagCommand : IRequest<IResult>
    {
        public int Id { get; set; }

        public class DeleteTrendyolProductTagCommandHandler : IRequestHandler<DeleteTrendyolProductTagCommand, IResult>
        {
            private readonly ITrendyolProductTagRepository _trendyolProductTagRepository;
            private readonly IMediator _mediator;

            public DeleteTrendyolProductTagCommandHandler(ITrendyolProductTagRepository trendyolProductTagRepository, IMediator mediator)
            {
                _trendyolProductTagRepository = trendyolProductTagRepository;
                _mediator = mediator;
            }

            [CacheRemoveAspect("Get")]
            [LogAspect(typeof(FileLogger))]
            [SecuredOperation(Priority = 1)]
            public async Task<IResult> Handle(DeleteTrendyolProductTagCommand request, CancellationToken cancellationToken)
            {
                var trendyolProductTagToDelete = _trendyolProductTagRepository.Get(p => p.Id == request.Id);

                _trendyolProductTagRepository.Delete(trendyolProductTagToDelete);
                await _trendyolProductTagRepository.SaveChangesAsync();
                return new SuccessResult(Messages.Deleted);
            }
        }
    }
}

