
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
using Business.Handlers.TrendyolProductTags.ValidationRules;


namespace Business.Handlers.TrendyolProductTags.Commands
{


    public class UpdateTrendyolProductTagCommand : IRequest<IResult>
    {
        public int Id { get; set; }
        public System.DateTime FetchDate { get; set; }
        public int ProductId { get; set; }
        public string TagName { get; set; }
        public int TagCount { get; set; }

        public class UpdateTrendyolProductTagCommandHandler : IRequestHandler<UpdateTrendyolProductTagCommand, IResult>
        {
            private readonly ITrendyolProductTagRepository _trendyolProductTagRepository;
            private readonly IMediator _mediator;

            public UpdateTrendyolProductTagCommandHandler(ITrendyolProductTagRepository trendyolProductTagRepository, IMediator mediator)
            {
                _trendyolProductTagRepository = trendyolProductTagRepository;
                _mediator = mediator;
            }

            [ValidationAspect(typeof(UpdateTrendyolProductTagValidator), Priority = 1)]
            [CacheRemoveAspect("Get")]
            [LogAspect(typeof(FileLogger))]
            [SecuredOperation(Priority = 1)]
            public async Task<IResult> Handle(UpdateTrendyolProductTagCommand request, CancellationToken cancellationToken)
            {
                var isThereTrendyolProductTagRecord = await _trendyolProductTagRepository.GetAsync(u => u.Id == request.Id);


                isThereTrendyolProductTagRecord.FetchDate = request.FetchDate;
                isThereTrendyolProductTagRecord.ProductId = request.ProductId;
                isThereTrendyolProductTagRecord.TagName = request.TagName;
                isThereTrendyolProductTagRecord.TagCount = request.TagCount;


                _trendyolProductTagRepository.Update(isThereTrendyolProductTagRecord);
                await _trendyolProductTagRepository.SaveChangesAsync();
                return new SuccessResult(Messages.Updated);
            }
        }
    }
}

