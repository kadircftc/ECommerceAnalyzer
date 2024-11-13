
using Business.Constants;
using Business.BusinessAspects;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Core.Aspects.Autofac.Validation;
using Business.Handlers.TrendyolProductImageses.ValidationRules;


namespace Business.Handlers.TrendyolProductImageses.Commands
{


    public class UpdateTrendyolProductImagesCommand : IRequest<IResult>
    {
        public int Id { get; set; }
        public System.DateTime FetchDate { get; set; }
        public int ProductId { get; set; }
        public string ImgUrl { get; set; }

        public class UpdateTrendyolProductImagesCommandHandler : IRequestHandler<UpdateTrendyolProductImagesCommand, IResult>
        {
            private readonly ITrendyolProductImagesRepository _trendyolProductImagesRepository;
            private readonly IMediator _mediator;

            public UpdateTrendyolProductImagesCommandHandler(ITrendyolProductImagesRepository trendyolProductImagesRepository, IMediator mediator)
            {
                _trendyolProductImagesRepository = trendyolProductImagesRepository;
                _mediator = mediator;
            }

            [ValidationAspect(typeof(UpdateTrendyolProductImagesValidator), Priority = 1)]
            [CacheRemoveAspect("Get")]
            [LogAspect(typeof(FileLogger))]
            [SecuredOperation(Priority = 1)]
            public async Task<IResult> Handle(UpdateTrendyolProductImagesCommand request, CancellationToken cancellationToken)
            {
                var isThereTrendyolProductImagesRecord = await _trendyolProductImagesRepository.GetAsync(u => u.Id == request.Id);


                isThereTrendyolProductImagesRecord.FetchDate = request.FetchDate;
                isThereTrendyolProductImagesRecord.ProductId = request.ProductId;
                isThereTrendyolProductImagesRecord.ImgUrl = request.ImgUrl;


                _trendyolProductImagesRepository.Update(isThereTrendyolProductImagesRecord);
                await _trendyolProductImagesRepository.SaveChangesAsync();
                return new SuccessResult(Messages.Updated);
            }
        }
    }
}

