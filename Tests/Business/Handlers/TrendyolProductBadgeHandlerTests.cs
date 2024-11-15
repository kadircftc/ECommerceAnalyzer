
using Business.Handlers.TrendyolProductBadges.Queries;
using DataAccess.Abstract;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using static Business.Handlers.TrendyolProductBadges.Queries.GetTrendyolProductBadgeQuery;
using Entities.Concrete;
using static Business.Handlers.TrendyolProductBadges.Queries.GetTrendyolProductBadgesQuery;
using static Business.Handlers.TrendyolProductBadges.Commands.CreateTrendyolProductBadgeCommand;
using Business.Handlers.TrendyolProductBadges.Commands;
using Business.Constants;
using static Business.Handlers.TrendyolProductBadges.Commands.UpdateTrendyolProductBadgeCommand;
using static Business.Handlers.TrendyolProductBadges.Commands.DeleteTrendyolProductBadgeCommand;
using MediatR;
using System.Linq;
using FluentAssertions;


namespace Tests.Business.HandlersTest
{
    [TestFixture]
    public class TrendyolProductBadgeHandlerTests
    {
        Mock<ITrendyolProductBadgeRepository> _trendyolProductBadgeRepository;
        Mock<IMediator> _mediator;
        [SetUp]
        public void Setup()
        {
            _trendyolProductBadgeRepository = new Mock<ITrendyolProductBadgeRepository>();
            _mediator = new Mock<IMediator>();
        }

        [Test]
        public async Task TrendyolProductBadge_GetQuery_Success()
        {
            //Arrange
            var query = new GetTrendyolProductBadgeQuery();

            _trendyolProductBadgeRepository.Setup(x => x.GetAsync(It.IsAny<Expression<Func<TrendyolProductBadge, bool>>>())).ReturnsAsync(new TrendyolProductBadge()
//propertyler buraya yazılacak
//{																		
//TrendyolProductBadgeId = 1,
//TrendyolProductBadgeName = "Test"
//}
);

            var handler = new GetTrendyolProductBadgeQueryHandler(_trendyolProductBadgeRepository.Object, _mediator.Object);

            //Act
            var x = await handler.Handle(query, new System.Threading.CancellationToken());

            //Asset
            x.Success.Should().BeTrue();
            //x.Data.TrendyolProductBadgeId.Should().Be(1);

        }

        [Test]
        public async Task TrendyolProductBadge_GetQueries_Success()
        {
            //Arrange
            var query = new GetTrendyolProductBadgesQuery();

            _trendyolProductBadgeRepository.Setup(x => x.GetListAsync(It.IsAny<Expression<Func<TrendyolProductBadge, bool>>>()))
                        .ReturnsAsync(new List<TrendyolProductBadge> { new TrendyolProductBadge() { /*TODO:propertyler buraya yazılacak TrendyolProductBadgeId = 1, TrendyolProductBadgeName = "test"*/ } });

            var handler = new GetTrendyolProductBadgesQueryHandler(_trendyolProductBadgeRepository.Object, _mediator.Object);

            //Act
            var x = await handler.Handle(query, new System.Threading.CancellationToken());

            //Asset
            x.Success.Should().BeTrue();
            ((List<TrendyolProductBadge>)x.Data).Count.Should().BeGreaterThan(1);

        }

        [Test]
        public async Task TrendyolProductBadge_CreateCommand_Success()
        {
            TrendyolProductBadge rt = null;
            //Arrange
            var command = new CreateTrendyolProductBadgeCommand();
            //propertyler buraya yazılacak
            //command.TrendyolProductBadgeName = "deneme";

            _trendyolProductBadgeRepository.Setup(x => x.GetAsync(It.IsAny<Expression<Func<TrendyolProductBadge, bool>>>()))
                        .ReturnsAsync(rt);

            _trendyolProductBadgeRepository.Setup(x => x.Add(It.IsAny<TrendyolProductBadge>())).Returns(new TrendyolProductBadge());

            var handler = new CreateTrendyolProductBadgeCommandHandler(_trendyolProductBadgeRepository.Object, _mediator.Object);
            var x = await handler.Handle(command, new System.Threading.CancellationToken());

            _trendyolProductBadgeRepository.Verify(x => x.SaveChangesAsync());
            x.Success.Should().BeTrue();
            x.Message.Should().Be(Messages.Added);
        }

        [Test]
        public async Task TrendyolProductBadge_CreateCommand_NameAlreadyExist()
        {
            //Arrange
            var command = new CreateTrendyolProductBadgeCommand();
            //propertyler buraya yazılacak 
            //command.TrendyolProductBadgeName = "test";

            _trendyolProductBadgeRepository.Setup(x => x.Query())
                                           .Returns(new List<TrendyolProductBadge> { new TrendyolProductBadge() { /*TODO:propertyler buraya yazılacak TrendyolProductBadgeId = 1, TrendyolProductBadgeName = "test"*/ } }.AsQueryable());

            _trendyolProductBadgeRepository.Setup(x => x.Add(It.IsAny<TrendyolProductBadge>())).Returns(new TrendyolProductBadge());

            var handler = new CreateTrendyolProductBadgeCommandHandler(_trendyolProductBadgeRepository.Object, _mediator.Object);
            var x = await handler.Handle(command, new System.Threading.CancellationToken());

            x.Success.Should().BeFalse();
            x.Message.Should().Be(Messages.NameAlreadyExist);
        }

        [Test]
        public async Task TrendyolProductBadge_UpdateCommand_Success()
        {
            //Arrange
            var command = new UpdateTrendyolProductBadgeCommand();
            //command.TrendyolProductBadgeName = "test";

            _trendyolProductBadgeRepository.Setup(x => x.GetAsync(It.IsAny<Expression<Func<TrendyolProductBadge, bool>>>()))
                        .ReturnsAsync(new TrendyolProductBadge() { /*TODO:propertyler buraya yazılacak TrendyolProductBadgeId = 1, TrendyolProductBadgeName = "deneme"*/ });

            _trendyolProductBadgeRepository.Setup(x => x.Update(It.IsAny<TrendyolProductBadge>())).Returns(new TrendyolProductBadge());

            var handler = new UpdateTrendyolProductBadgeCommandHandler(_trendyolProductBadgeRepository.Object, _mediator.Object);
            var x = await handler.Handle(command, new System.Threading.CancellationToken());

            _trendyolProductBadgeRepository.Verify(x => x.SaveChangesAsync());
            x.Success.Should().BeTrue();
            x.Message.Should().Be(Messages.Updated);
        }

        [Test]
        public async Task TrendyolProductBadge_DeleteCommand_Success()
        {
            //Arrange
            var command = new DeleteTrendyolProductBadgeCommand();

            _trendyolProductBadgeRepository.Setup(x => x.GetAsync(It.IsAny<Expression<Func<TrendyolProductBadge, bool>>>()))
                        .ReturnsAsync(new TrendyolProductBadge() { /*TODO:propertyler buraya yazılacak TrendyolProductBadgeId = 1, TrendyolProductBadgeName = "deneme"*/});

            _trendyolProductBadgeRepository.Setup(x => x.Delete(It.IsAny<TrendyolProductBadge>()));

            var handler = new DeleteTrendyolProductBadgeCommandHandler(_trendyolProductBadgeRepository.Object, _mediator.Object);
            var x = await handler.Handle(command, new System.Threading.CancellationToken());

            _trendyolProductBadgeRepository.Verify(x => x.SaveChangesAsync());
            x.Success.Should().BeTrue();
            x.Message.Should().Be(Messages.Deleted);
        }
    }
}

