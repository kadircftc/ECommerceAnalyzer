
using Business.BusinessAspects;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Business.Handlers.TrendyolProductImageses.ValidationRules;

namespace Business.Handlers.TrendyolProductImageses.Commands
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateTrendyolProductImagesCommand : IRequest<IResult>
    {

        public System.DateTime FetchDate { get; set; }
        public int ProductId { get; set; }
        public string ImgUrl { get; set; }


        public class CreateTrendyolProductImagesCommandHandler : IRequestHandler<CreateTrendyolProductImagesCommand, IResult>
        {
            private readonly ITrendyolProductImagesRepository _trendyolProductImagesRepository;
            private readonly IMediator _mediator;
            public CreateTrendyolProductImagesCommandHandler(ITrendyolProductImagesRepository trendyolProductImagesRepository, IMediator mediator)
            {
                _trendyolProductImagesRepository = trendyolProductImagesRepository;
                _mediator = mediator;
            }

            [ValidationAspect(typeof(CreateTrendyolProductImagesValidator), Priority = 1)]
            [CacheRemoveAspect("Get")]
            [LogAspect(typeof(FileLogger))]
            [SecuredOperation(Priority = 1)]
            public async Task<IResult> Handle(CreateTrendyolProductImagesCommand request, CancellationToken cancellationToken)
            {
                var isThereTrendyolProductImagesRecord = _trendyolProductImagesRepository.Query().Any(u => u.FetchDate == request.FetchDate);

                if (isThereTrendyolProductImagesRecord == true)
                    return new ErrorResult(Messages.NameAlreadyExist);

                var addedTrendyolProductImages = new TrendyolProductImages
                {
                    FetchDate = request.FetchDate,
                    ProductId = request.ProductId,
                    ImgUrl = request.ImgUrl,

                };

                _trendyolProductImagesRepository.Add(addedTrendyolProductImages);
                await _trendyolProductImagesRepository.SaveChangesAsync();
                return new SuccessResult(Messages.Added);
            }
        }
    }
}