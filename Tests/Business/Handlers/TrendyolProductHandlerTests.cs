
using Business.Handlers.TrendyolProducts.Queries;
using DataAccess.Abstract;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using static Business.Handlers.TrendyolProducts.Queries.GetTrendyolProductQuery;
using Entities.Concrete;
using static Business.Handlers.TrendyolProducts.Queries.GetTrendyolProductsQuery;
using static Business.Handlers.TrendyolProducts.Commands.CreateTrendyolProductCommand;
using Business.Handlers.TrendyolProducts.Commands;
using Business.Constants;
using static Business.Handlers.TrendyolProducts.Commands.UpdateTrendyolProductCommand;
using static Business.Handlers.TrendyolProducts.Commands.DeleteTrendyolProductCommand;
using MediatR;
using System.Linq;
using FluentAssertions;


namespace Tests.Business.HandlersTest
{
    [TestFixture]
    public class TrendyolProductHandlerTests
    {
        Mock<ITrendyolProductRepository> _trendyolProductRepository;
        Mock<IMediator> _mediator;
        [SetUp]
        public void Setup()
        {
            _trendyolProductRepository = new Mock<ITrendyolProductRepository>();
            _mediator = new Mock<IMediator>();
        }

        [Test]
        public async Task TrendyolProduct_GetQuery_Success()
        {
            //Arrange
            var query = new GetTrendyolProductQuery();

            _trendyolProductRepository.Setup(x => x.GetAsync(It.IsAny<Expression<Func<TrendyolProduct, bool>>>())).ReturnsAsync(new TrendyolProduct()
//propertyler buraya yazılacak
//{																		
//TrendyolProductId = 1,
//TrendyolProductName = "Test"
//}
);

            var handler = new GetTrendyolProductQueryHandler(_trendyolProductRepository.Object, _mediator.Object);

            //Act
            var x = await handler.Handle(query, new System.Threading.CancellationToken());

            //Asset
            x.Success.Should().BeTrue();
            //x.Data.TrendyolProductId.Should().Be(1);

        }

        [Test]
        public async Task TrendyolProduct_GetQueries_Success()
        {
            //Arrange
            var query = new GetTrendyolProductsQuery();

            _trendyolProductRepository.Setup(x => x.GetListAsync(It.IsAny<Expression<Func<TrendyolProduct, bool>>>()))
                        .ReturnsAsync(new List<TrendyolProduct> { new TrendyolProduct() { /*TODO:propertyler buraya yazılacak TrendyolProductId = 1, TrendyolProductName = "test"*/ } });

            var handler = new GetTrendyolProductsQueryHandler(_trendyolProductRepository.Object, _mediator.Object);

            //Act
            var x = await handler.Handle(query, new System.Threading.CancellationToken());

            //Asset
            x.Success.Should().BeTrue();
            ((List<TrendyolProduct>)x.Data).Count.Should().BeGreaterThan(1);

        }

        [Test]
        public async Task TrendyolProduct_CreateCommand_Success()
        {
            TrendyolProduct rt = null;
            //Arrange
            var command = new CreateTrendyolProductCommand();
            //propertyler buraya yazılacak
            //command.TrendyolProductName = "deneme";

            _trendyolProductRepository.Setup(x => x.GetAsync(It.IsAny<Expression<Func<TrendyolProduct, bool>>>()))
                        .ReturnsAsync(rt);

            _trendyolProductRepository.Setup(x => x.Add(It.IsAny<TrendyolProduct>())).Returns(new TrendyolProduct());

            var handler = new CreateTrendyolProductCommandHandler(_trendyolProductRepository.Object, _mediator.Object);
            var x = await handler.Handle(command, new System.Threading.CancellationToken());

            _trendyolProductRepository.Verify(x => x.SaveChangesAsync());
            x.Success.Should().BeTrue();
            x.Message.Should().Be(Messages.Added);
        }

        [Test]
        public async Task TrendyolProduct_CreateCommand_NameAlreadyExist()
        {
            //Arrange
            var command = new CreateTrendyolProductCommand();
            //propertyler buraya yazılacak 
            //command.TrendyolProductName = "test";

            _trendyolProductRepository.Setup(x => x.Query())
                                           .Returns(new List<TrendyolProduct> { new TrendyolProduct() { /*TODO:propertyler buraya yazılacak TrendyolProductId = 1, TrendyolProductName = "test"*/ } }.AsQueryable());

            _trendyolProductRepository.Setup(x => x.Add(It.IsAny<TrendyolProduct>())).Returns(new TrendyolProduct());

            var handler = new CreateTrendyolProductCommandHandler(_trendyolProductRepository.Object, _mediator.Object);
            var x = await handler.Handle(command, new System.Threading.CancellationToken());

            x.Success.Should().BeFalse();
            x.Message.Should().Be(Messages.NameAlreadyExist);
        }

        [Test]
        public async Task TrendyolProduct_UpdateCommand_Success()
        {
            //Arrange
            var command = new UpdateTrendyolProductCommand();
            //command.TrendyolProductName = "test";

            _trendyolProductRepository.Setup(x => x.GetAsync(It.IsAny<Expression<Func<TrendyolProduct, bool>>>()))
                        .ReturnsAsync(new TrendyolProduct() { /*TODO:propertyler buraya yazılacak TrendyolProductId = 1, TrendyolProductName = "deneme"*/ });

            _trendyolProductRepository.Setup(x => x.Update(It.IsAny<TrendyolProduct>())).Returns(new TrendyolProduct());

            var handler = new UpdateTrendyolProductCommandHandler(_trendyolProductRepository.Object, _mediator.Object);
            var x = await handler.Handle(command, new System.Threading.CancellationToken());

            _trendyolProductRepository.Verify(x => x.SaveChangesAsync());
            x.Success.Should().BeTrue();
            x.Message.Should().Be(Messages.Updated);
        }

        [Test]
        public async Task TrendyolProduct_DeleteCommand_Success()
        {
            //Arrange
            var command = new DeleteTrendyolProductCommand();

            _trendyolProductRepository.Setup(x => x.GetAsync(It.IsAny<Expression<Func<TrendyolProduct, bool>>>()))
                        .ReturnsAsync(new TrendyolProduct() { /*TODO:propertyler buraya yazılacak TrendyolProductId = 1, TrendyolProductName = "deneme"*/});

            _trendyolProductRepository.Setup(x => x.Delete(It.IsAny<TrendyolProduct>()));

            var handler = new DeleteTrendyolProductCommandHandler(_trendyolProductRepository.Object, _mediator.Object);
            var x = await handler.Handle(command, new System.Threading.CancellationToken());

            _trendyolProductRepository.Verify(x => x.SaveChangesAsync());
            x.Success.Should().BeTrue();
            x.Message.Should().Be(Messages.Deleted);
        }
    }
}

