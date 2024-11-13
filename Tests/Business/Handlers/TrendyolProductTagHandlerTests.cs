
using Business.Handlers.TrendyolProductTags.Queries;
using DataAccess.Abstract;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using static Business.Handlers.TrendyolProductTags.Queries.GetTrendyolProductTagQuery;
using Entities.Concrete;
using static Business.Handlers.TrendyolProductTags.Queries.GetTrendyolProductTagsQuery;
using static Business.Handlers.TrendyolProductTags.Commands.CreateTrendyolProductTagCommand;
using Business.Handlers.TrendyolProductTags.Commands;
using Business.Constants;
using static Business.Handlers.TrendyolProductTags.Commands.UpdateTrendyolProductTagCommand;
using static Business.Handlers.TrendyolProductTags.Commands.DeleteTrendyolProductTagCommand;
using MediatR;
using System.Linq;
using FluentAssertions;


namespace Tests.Business.HandlersTest
{
    [TestFixture]
    public class TrendyolProductTagHandlerTests
    {
        Mock<ITrendyolProductTagRepository> _trendyolProductTagRepository;
        Mock<IMediator> _mediator;
        [SetUp]
        public void Setup()
        {
            _trendyolProductTagRepository = new Mock<ITrendyolProductTagRepository>();
            _mediator = new Mock<IMediator>();
        }

        [Test]
        public async Task TrendyolProductTag_GetQuery_Success()
        {
            //Arrange
            var query = new GetTrendyolProductTagQuery();

            _trendyolProductTagRepository.Setup(x => x.GetAsync(It.IsAny<Expression<Func<TrendyolProductTag, bool>>>())).ReturnsAsync(new TrendyolProductTag()
//propertyler buraya yazılacak
//{																		
//TrendyolProductTagId = 1,
//TrendyolProductTagName = "Test"
//}
);

            var handler = new GetTrendyolProductTagQueryHandler(_trendyolProductTagRepository.Object, _mediator.Object);

            //Act
            var x = await handler.Handle(query, new System.Threading.CancellationToken());

            //Asset
            x.Success.Should().BeTrue();
            //x.Data.TrendyolProductTagId.Should().Be(1);

        }

        [Test]
        public async Task TrendyolProductTag_GetQueries_Success()
        {
            //Arrange
            var query = new GetTrendyolProductTagsQuery();

            _trendyolProductTagRepository.Setup(x => x.GetListAsync(It.IsAny<Expression<Func<TrendyolProductTag, bool>>>()))
                        .ReturnsAsync(new List<TrendyolProductTag> { new TrendyolProductTag() { /*TODO:propertyler buraya yazılacak TrendyolProductTagId = 1, TrendyolProductTagName = "test"*/ } });

            var handler = new GetTrendyolProductTagsQueryHandler(_trendyolProductTagRepository.Object, _mediator.Object);

            //Act
            var x = await handler.Handle(query, new System.Threading.CancellationToken());

            //Asset
            x.Success.Should().BeTrue();
            ((List<TrendyolProductTag>)x.Data).Count.Should().BeGreaterThan(1);

        }

        [Test]
        public async Task TrendyolProductTag_CreateCommand_Success()
        {
            TrendyolProductTag rt = null;
            //Arrange
            var command = new CreateTrendyolProductTagCommand();
            //propertyler buraya yazılacak
            //command.TrendyolProductTagName = "deneme";

            _trendyolProductTagRepository.Setup(x => x.GetAsync(It.IsAny<Expression<Func<TrendyolProductTag, bool>>>()))
                        .ReturnsAsync(rt);

            _trendyolProductTagRepository.Setup(x => x.Add(It.IsAny<TrendyolProductTag>())).Returns(new TrendyolProductTag());

            var handler = new CreateTrendyolProductTagCommandHandler(_trendyolProductTagRepository.Object, _mediator.Object);
            var x = await handler.Handle(command, new System.Threading.CancellationToken());

            _trendyolProductTagRepository.Verify(x => x.SaveChangesAsync());
            x.Success.Should().BeTrue();
            x.Message.Should().Be(Messages.Added);
        }

        [Test]
        public async Task TrendyolProductTag_CreateCommand_NameAlreadyExist()
        {
            //Arrange
            var command = new CreateTrendyolProductTagCommand();
            //propertyler buraya yazılacak 
            //command.TrendyolProductTagName = "test";

            _trendyolProductTagRepository.Setup(x => x.Query())
                                           .Returns(new List<TrendyolProductTag> { new TrendyolProductTag() { /*TODO:propertyler buraya yazılacak TrendyolProductTagId = 1, TrendyolProductTagName = "test"*/ } }.AsQueryable());

            _trendyolProductTagRepository.Setup(x => x.Add(It.IsAny<TrendyolProductTag>())).Returns(new TrendyolProductTag());

            var handler = new CreateTrendyolProductTagCommandHandler(_trendyolProductTagRepository.Object, _mediator.Object);
            var x = await handler.Handle(command, new System.Threading.CancellationToken());

            x.Success.Should().BeFalse();
            x.Message.Should().Be(Messages.NameAlreadyExist);
        }

        [Test]
        public async Task TrendyolProductTag_UpdateCommand_Success()
        {
            //Arrange
            var command = new UpdateTrendyolProductTagCommand();
            //command.TrendyolProductTagName = "test";

            _trendyolProductTagRepository.Setup(x => x.GetAsync(It.IsAny<Expression<Func<TrendyolProductTag, bool>>>()))
                        .ReturnsAsync(new TrendyolProductTag() { /*TODO:propertyler buraya yazılacak TrendyolProductTagId = 1, TrendyolProductTagName = "deneme"*/ });

            _trendyolProductTagRepository.Setup(x => x.Update(It.IsAny<TrendyolProductTag>())).Returns(new TrendyolProductTag());

            var handler = new UpdateTrendyolProductTagCommandHandler(_trendyolProductTagRepository.Object, _mediator.Object);
            var x = await handler.Handle(command, new System.Threading.CancellationToken());

            _trendyolProductTagRepository.Verify(x => x.SaveChangesAsync());
            x.Success.Should().BeTrue();
            x.Message.Should().Be(Messages.Updated);
        }

        [Test]
        public async Task TrendyolProductTag_DeleteCommand_Success()
        {
            //Arrange
            var command = new DeleteTrendyolProductTagCommand();

            _trendyolProductTagRepository.Setup(x => x.GetAsync(It.IsAny<Expression<Func<TrendyolProductTag, bool>>>()))
                        .ReturnsAsync(new TrendyolProductTag() { /*TODO:propertyler buraya yazılacak TrendyolProductTagId = 1, TrendyolProductTagName = "deneme"*/});

            _trendyolProductTagRepository.Setup(x => x.Delete(It.IsAny<TrendyolProductTag>()));

            var handler = new DeleteTrendyolProductTagCommandHandler(_trendyolProductTagRepository.Object, _mediator.Object);
            var x = await handler.Handle(command, new System.Threading.CancellationToken());

            _trendyolProductTagRepository.Verify(x => x.SaveChangesAsync());
            x.Success.Should().BeTrue();
            x.Message.Should().Be(Messages.Deleted);
        }
    }
}

