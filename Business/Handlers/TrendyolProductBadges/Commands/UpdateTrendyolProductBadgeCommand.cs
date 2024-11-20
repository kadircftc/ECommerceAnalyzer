
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
using Business.Handlers.TrendyolProductBadges.ValidationRules;


namespace Business.Handlers.TrendyolProductBadges.Commands
{


    public class UpdateTrendyolProductBadgeCommand : IRequest<IResult>
    {
        public int Id { get; set; }
        public System.DateTime FetchDate { get; set; }
        public int ProductId { get; set; }
        public int MerchantId { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }

        public class UpdateTrendyolProductBadgeCommandHandler : IRequestHandler<UpdateTrendyolProductBadgeCommand, IResult>
        {
            private readonly ITrendyolProductBadgeRepository _trendyolProductBadgeRepository;
            private readonly IMediator _mediator;

            public UpdateTrendyolProductBadgeCommandHandler(ITrendyolProductBadgeRepository trendyolProductBadgeRepository, IMediator mediator)
            {
                _trendyolProductBadgeRepository = trendyolProductBadgeRepository;
                _mediator = mediator;
            }

            [ValidationAspect(typeof(UpdateTrendyolProductBadgeValidator), Priority = 1)]
            [CacheRemoveAspect("Get")]
            [LogAspect(typeof(FileLogger))]
            [SecuredOperation(Priority = 1)]
            public async Task<IResult> Handle(UpdateTrendyolProductBadgeCommand request, CancellationToken cancellationToken)
            {
                var isThereTrendyolProductBadgeRecord = await _trendyolProductBadgeRepository.GetAsync(u => u.Id == request.Id);


                isThereTrendyolProductBadgeRecord.FetchDate = request.FetchDate;
                isThereTrendyolProductBadgeRecord.ProductId = request.ProductId;
                isThereTrendyolProductBadgeRecord.MerchantId = request.MerchantId;
                isThereTrendyolProductBadgeRecord.Title = request.Title;
                isThereTrendyolProductBadgeRecord.Type = request.Type;


                _trendyolProductBadgeRepository.Update(isThereTrendyolProductBadgeRecord);
                await _trendyolProductBadgeRepository.SaveChangesAsync();
                return new SuccessResult(Messages.Updated);
            }
        }
    }
}

