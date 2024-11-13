
using Business.BusinessAspects;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;


namespace Business.Handlers.TrendyolProductImageses.Queries
{
    public class GetTrendyolProductImagesQuery : IRequest<IDataResult<TrendyolProductImages>>
    {
        public int Id { get; set; }

        public class GetTrendyolProductImagesQueryHandler : IRequestHandler<GetTrendyolProductImagesQuery, IDataResult<TrendyolProductImages>>
        {
            private readonly ITrendyolProductImagesRepository _trendyolProductImagesRepository;
            private readonly IMediator _mediator;

            public GetTrendyolProductImagesQueryHandler(ITrendyolProductImagesRepository trendyolProductImagesRepository, IMediator mediator)
            {
                _trendyolProductImagesRepository = trendyolProductImagesRepository;
                _mediator = mediator;
            }
            [LogAspect(typeof(FileLogger))]
            [SecuredOperation(Priority = 1)]
            public async Task<IDataResult<TrendyolProductImages>> Handle(GetTrendyolProductImagesQuery request, CancellationToken cancellationToken)
            {
                var trendyolProductImages = await _trendyolProductImagesRepository.GetAsync(p => p.Id == request.Id);
                return new SuccessDataResult<TrendyolProductImages>(trendyolProductImages);
            }
        }
    }
}
