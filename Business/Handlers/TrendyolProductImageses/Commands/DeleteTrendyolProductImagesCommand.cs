
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


namespace Business.Handlers.TrendyolProductImageses.Commands
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteTrendyolProductImagesCommand : IRequest<IResult>
    {
        public int Id { get; set; }

        public class DeleteTrendyolProductImagesCommandHandler : IRequestHandler<DeleteTrendyolProductImagesCommand, IResult>
        {
            private readonly ITrendyolProductImagesRepository _trendyolProductImagesRepository;
            private readonly IMediator _mediator;

            public DeleteTrendyolProductImagesCommandHandler(ITrendyolProductImagesRepository trendyolProductImagesRepository, IMediator mediator)
            {
                _trendyolProductImagesRepository = trendyolProductImagesRepository;
                _mediator = mediator;
            }

            [CacheRemoveAspect("Get")]
            [LogAspect(typeof(FileLogger))]
            [SecuredOperation(Priority = 1)]
            public async Task<IResult> Handle(DeleteTrendyolProductImagesCommand request, CancellationToken cancellationToken)
            {
                var trendyolProductImagesToDelete = _trendyolProductImagesRepository.Get(p => p.Id == request.Id);

                _trendyolProductImagesRepository.Delete(trendyolProductImagesToDelete);
                await _trendyolProductImagesRepository.SaveChangesAsync();
                return new SuccessResult(Messages.Deleted);
            }
        }
    }
}

