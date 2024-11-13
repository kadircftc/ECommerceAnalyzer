
using Business.Handlers.TrendyolProductImageses.Queries;
using DataAccess.Abstract;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using static Business.Handlers.TrendyolProductImageses.Queries.GetTrendyolProductImagesQuery;
using Entities.Concrete;
using static Business.Handlers.TrendyolProductImageses.Queries.GetTrendyolProductImagesesQuery;
using static Business.Handlers.TrendyolProductImageses.Commands.CreateTrendyolProductImagesCommand;
using Business.Handlers.TrendyolProductImageses.Commands;
using Business.Constants;
using static Business.Handlers.TrendyolProductImageses.Commands.UpdateTrendyolProductImagesCommand;
using static Business.Handlers.TrendyolProductImageses.Commands.DeleteTrendyolProductImagesCommand;
using MediatR;
using System.Linq;
using FluentAssertions;


namespace Tests.Business.HandlersTest
{
    [TestFixture]
    public class TrendyolProductImagesHandlerTests
    {
        Mock<ITrendyolProductImagesRepository> _trendyolProductImagesRepository;
        Mock<IMediator> _mediator;
        [SetUp]
        public void Setup()
        {
            _trendyolProductImagesRepository = new Mock<ITrendyolProductImagesRepository>();
            _mediator = new Mock<IMediator>();
        }

        [Test]
        public async Task TrendyolProductImages_GetQuery_Success()
        {
            //Arrange
            var query = new GetTrendyolProductImagesQuery();

            _trendyolProductImagesRepository.Setup(x => x.GetAsync(It.IsAny<Expression<Func<TrendyolProductImages, bool>>>())).ReturnsAsync(new TrendyolProductImages()
//propertyler buraya yazılacak
//{																		
//TrendyolProductImagesId = 1,
//TrendyolProductImagesName = "Test"
//}
);

            var handler = new GetTrendyolProductImagesQueryHandler(_trendyolProductImagesRepository.Object, _mediator.Object);

            //Act
            var x = await handler.Handle(query, new System.Threading.CancellationToken());

            //Asset
            x.Success.Should().BeTrue();
            //x.Data.TrendyolProductImagesId.Should().Be(1);

        }

        [Test]
        public async Task TrendyolProductImages_GetQueries_Success()
        {
            //Arrange
            var query = new GetTrendyolProductImagesesQuery();

            _trendyolProductImagesRepository.Setup(x => x.GetListAsync(It.IsAny<Expression<Func<TrendyolProductImages, bool>>>()))
                        .ReturnsAsync(new List<TrendyolProductImages> { new TrendyolProductImages() { /*TODO:propertyler buraya yazılacak TrendyolProductImagesId = 1, TrendyolProductImagesName = "test"*/ } });

            var handler = new GetTrendyolProductImagesesQueryHandler(_trendyolProductImagesRepository.Object, _mediator.Object);

            //Act
            var x = await handler.Handle(query, new System.Threading.CancellationToken());

            //Asset
            x.Success.Should().BeTrue();
            ((List<TrendyolProductImages>)x.Data).Count.Should().BeGreaterThan(1);

        }

        [Test]
        public async Task TrendyolProductImages_CreateCommand_Success()
        {
            TrendyolProductImages rt = null;
            //Arrange
            var command = new CreateTrendyolProductImagesCommand();
            //propertyler buraya yazılacak
            //command.TrendyolProductImagesName = "deneme";

            _trendyolProductImagesRepository.Setup(x => x.GetAsync(It.IsAny<Expression<Func<TrendyolProductImages, bool>>>()))
                        .ReturnsAsync(rt);

            _trendyolProductImagesRepository.Setup(x => x.Add(It.IsAny<TrendyolProductImages>())).Returns(new TrendyolProductImages());

            var handler = new CreateTrendyolProductImagesCommandHandler(_trendyolProductImagesRepository.Object, _mediator.Object);
            var x = await handler.Handle(command, new System.Threading.CancellationToken());

            _trendyolProductImagesRepository.Verify(x => x.SaveChangesAsync());
            x.Success.Should().BeTrue();
            x.Message.Should().Be(Messages.Added);
        }

        [Test]
        public async Task TrendyolProductImages_CreateCommand_NameAlreadyExist()
        {
            //Arrange
            var command = new CreateTrendyolProductImagesCommand();
            //propertyler buraya yazılacak 
            //command.TrendyolProductImagesName = "test";

            _trendyolProductImagesRepository.Setup(x => x.Query())
                                           .Returns(new List<TrendyolProductImages> { new TrendyolProductImages() { /*TODO:propertyler buraya yazılacak TrendyolProductImagesId = 1, TrendyolProductImagesName = "test"*/ } }.AsQueryable());

            _trendyolProductImagesRepository.Setup(x => x.Add(It.IsAny<TrendyolProductImages>())).Returns(new TrendyolProductImages());

            var handler = new CreateTrendyolProductImagesCommandHandler(_trendyolProductImagesRepository.Object, _mediator.Object);
            var x = await handler.Handle(command, new System.Threading.CancellationToken());

            x.Success.Should().BeFalse();
            x.Message.Should().Be(Messages.NameAlreadyExist);
        }

        [Test]
        public async Task TrendyolProductImages_UpdateCommand_Success()
        {
            //Arrange
            var command = new UpdateTrendyolProductImagesCommand();
            //command.TrendyolProductImagesName = "test";

            _trendyolProductImagesRepository.Setup(x => x.GetAsync(It.IsAny<Expression<Func<TrendyolProductImages, bool>>>()))
                        .ReturnsAsync(new TrendyolProductImages() { /*TODO:propertyler buraya yazılacak TrendyolProductImagesId = 1, TrendyolProductImagesName = "deneme"*/ });

            _trendyolProductImagesRepository.Setup(x => x.Update(It.IsAny<TrendyolProductImages>())).Returns(new TrendyolProductImages());

            var handler = new UpdateTrendyolProductImagesCommandHandler(_trendyolProductImagesRepository.Object, _mediator.Object);
            var x = await handler.Handle(command, new System.Threading.CancellationToken());

            _trendyolProductImagesRepository.Verify(x => x.SaveChangesAsync());
            x.Success.Should().BeTrue();
            x.Message.Should().Be(Messages.Updated);
        }

        [Test]
        public async Task TrendyolProductImages_DeleteCommand_Success()
        {
            //Arrange
            var command = new DeleteTrendyolProductImagesCommand();

            _trendyolProductImagesRepository.Setup(x => x.GetAsync(It.IsAny<Expression<Func<TrendyolProductImages, bool>>>()))
                        .ReturnsAsync(new TrendyolProductImages() { /*TODO:propertyler buraya yazılacak TrendyolProductImagesId = 1, TrendyolProductImagesName = "deneme"*/});

            _trendyolProductImagesRepository.Setup(x => x.Delete(It.IsAny<TrendyolProductImages>()));

            var handler = new DeleteTrendyolProductImagesCommandHandler(_trendyolProductImagesRepository.Object, _mediator.Object);
            var x = await handler.Handle(command, new System.Threading.CancellationToken());

            _trendyolProductImagesRepository.Verify(x => x.SaveChangesAsync());
            x.Success.Should().BeTrue();
            x.Message.Should().Be(Messages.Deleted);
        }
    }
}

