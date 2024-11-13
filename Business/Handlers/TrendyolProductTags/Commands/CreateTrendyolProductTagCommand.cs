
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
using Business.Handlers.TrendyolProductTags.ValidationRules;

namespace Business.Handlers.TrendyolProductTags.Commands
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateTrendyolProductTagCommand : IRequest<IResult>
    {

        public System.DateTime FetchDate { get; set; }
        public int ProductId { get; set; }
        public string TagName { get; set; }
        public int TagCount { get; set; }


        public class CreateTrendyolProductTagCommandHandler : IRequestHandler<CreateTrendyolProductTagCommand, IResult>
        {
            private readonly ITrendyolProductTagRepository _trendyolProductTagRepository;
            private readonly IMediator _mediator;
            public CreateTrendyolProductTagCommandHandler(ITrendyolProductTagRepository trendyolProductTagRepository, IMediator mediator)
            {
                _trendyolProductTagRepository = trendyolProductTagRepository;
                _mediator = mediator;
            }

            [ValidationAspect(typeof(CreateTrendyolProductTagValidator), Priority = 1)]
            [CacheRemoveAspect("Get")]
            [LogAspect(typeof(FileLogger))]
            [SecuredOperation(Priority = 1)]
            public async Task<IResult> Handle(CreateTrendyolProductTagCommand request, CancellationToken cancellationToken)
            {
                var isThereTrendyolProductTagRecord = _trendyolProductTagRepository.Query().Any(u => u.FetchDate == request.FetchDate);

                if (isThereTrendyolProductTagRecord == true)
                    return new ErrorResult(Messages.NameAlreadyExist);

                var addedTrendyolProductTag = new TrendyolProductTag
                {
                    FetchDate = request.FetchDate,
                    ProductId = request.ProductId,
                    TagName = request.TagName,
                    TagCount = request.TagCount,

                };

                _trendyolProductTagRepository.Add(addedTrendyolProductTag);
                await _trendyolProductTagRepository.SaveChangesAsync();
                return new SuccessResult(Messages.Added);
            }
        }
    }
}