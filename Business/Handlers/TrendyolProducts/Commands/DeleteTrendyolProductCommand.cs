
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


namespace Business.Handlers.TrendyolProducts.Commands
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteTrendyolProductCommand : IRequest<IResult>
    {
        public int Id { get; set; }

        public class DeleteTrendyolProductCommandHandler : IRequestHandler<DeleteTrendyolProductCommand, IResult>
        {
            private readonly ITrendyolProductRepository _trendyolProductRepository;
            private readonly IMediator _mediator;

            public DeleteTrendyolProductCommandHandler(ITrendyolProductRepository trendyolProductRepository, IMediator mediator)
            {
                _trendyolProductRepository = trendyolProductRepository;
                _mediator = mediator;
            }

            [CacheRemoveAspect("Get")]
            [LogAspect(typeof(FileLogger))]
            [SecuredOperation(Priority = 1)]
            public async Task<IResult> Handle(DeleteTrendyolProductCommand request, CancellationToken cancellationToken)
            {
                var trendyolProductToDelete = _trendyolProductRepository.Get(p => p.Id == request.Id);

                _trendyolProductRepository.Delete(trendyolProductToDelete);
                await _trendyolProductRepository.SaveChangesAsync();
                return new SuccessResult(Messages.Deleted);
            }
        }
    }
}

