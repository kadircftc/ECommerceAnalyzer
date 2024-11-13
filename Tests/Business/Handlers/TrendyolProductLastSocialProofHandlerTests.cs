
using Business.Handlers.TrendyolProductLastSocialProoves.Queries;
using DataAccess.Abstract;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using static Business.Handlers.TrendyolProductLastSocialProoves.Queries.GetTrendyolProductLastSocialProofQuery;
using Entities.Concrete;
using static Business.Handlers.TrendyolProductLastSocialProoves.Queries.GetTrendyolProductLastSocialProovesQuery;
using static Business.Handlers.TrendyolProductLastSocialProoves.Commands.CreateTrendyolProductLastSocialProofCommand;
using Business.Handlers.TrendyolProductLastSocialProoves.Commands;
using Business.Constants;
using static Business.Handlers.TrendyolProductLastSocialProoves.Commands.UpdateTrendyolProductLastSocialProofCommand;
using static Business.Handlers.TrendyolProductLastSocialProoves.Commands.DeleteTrendyolProductLastSocialProofCommand;
using MediatR;
using System.Linq;
using FluentAssertions;


namespace Tests.Business.HandlersTest
{
    [TestFixture]
    public class TrendyolProductLastSocialProofHandlerTests
    {
        Mock<ITrendyolProductLastSocialProofRepository> _trendyolProductLastSocialProofRepository;
        Mock<IMediator> _mediator;
        [SetUp]
        public void Setup()
        {
            _trendyolProductLastSocialProofRepository = new Mock<ITrendyolProductLastSocialProofRepository>();
            _mediator = new Mock<IMediator>();
        }

        [Test]
        public async Task TrendyolProductLastSocialProof_GetQuery_Success()
        {
            //Arrange
            var query = new GetTrendyolProductLastSocialProofQuery();

            _trendyolProductLastSocialProofRepository.Setup(x => x.GetAsync(It.IsAny<Expression<Func<TrendyolProductLastSocialProof, bool>>>())).ReturnsAsync(new TrendyolProductLastSocialProof()
//propertyler buraya yazılacak
//{																		
//TrendyolProductLastSocialProofId = 1,
//TrendyolProductLastSocialProofName = "Test"
//}
);

            var handler = new GetTrendyolProductLastSocialProofQueryHandler(_trendyolProductLastSocialProofRepository.Object, _mediator.Object);

            //Act
            var x = await handler.Handle(query, new System.Threading.CancellationToken());

            //Asset
            x.Success.Should().BeTrue();
            //x.Data.TrendyolProductLastSocialProofId.Should().Be(1);

        }

        [Test]
        public async Task TrendyolProductLastSocialProof_GetQueries_Success()
        {
            //Arrange
            var query = new GetTrendyolProductLastSocialProovesQuery();

            _trendyolProductLastSocialProofRepository.Setup(x => x.GetListAsync(It.IsAny<Expression<Func<TrendyolProductLastSocialProof, bool>>>()))
                        .ReturnsAsync(new List<TrendyolProductLastSocialProof> { new TrendyolProductLastSocialProof() { /*TODO:propertyler buraya yazılacak TrendyolProductLastSocialProofId = 1, TrendyolProductLastSocialProofName = "test"*/ } });

            var handler = new GetTrendyolProductLastSocialProovesQueryHandler(_trendyolProductLastSocialProofRepository.Object, _mediator.Object);

            //Act
            var x = await handler.Handle(query, new System.Threading.CancellationToken());

            //Asset
            x.Success.Should().BeTrue();
            ((List<TrendyolProductLastSocialProof>)x.Data).Count.Should().BeGreaterThan(1);

        }

        [Test]
        public async Task TrendyolProductLastSocialProof_CreateCommand_Success()
        {
            TrendyolProductLastSocialProof rt = null;
            //Arrange
            var command = new CreateTrendyolProductLastSocialProofCommand();
            //propertyler buraya yazılacak
            //command.TrendyolProductLastSocialProofName = "deneme";

            _trendyolProductLastSocialProofRepository.Setup(x => x.GetAsync(It.IsAny<Expression<Func<TrendyolProductLastSocialProof, bool>>>()))
                        .ReturnsAsync(rt);

            _trendyolProductLastSocialProofRepository.Setup(x => x.Add(It.IsAny<TrendyolProductLastSocialProof>())).Returns(new TrendyolProductLastSocialProof());

            var handler = new CreateTrendyolProductLastSocialProofCommandHandler(_trendyolProductLastSocialProofRepository.Object, _mediator.Object);
            var x = await handler.Handle(command, new System.Threading.CancellationToken());

            _trendyolProductLastSocialProofRepository.Verify(x => x.SaveChangesAsync());
            x.Success.Should().BeTrue();
            x.Message.Should().Be(Messages.Added);
        }

        [Test]
        public async Task TrendyolProductLastSocialProof_CreateCommand_NameAlreadyExist()
        {
            //Arrange
            var command = new CreateTrendyolProductLastSocialProofCommand();
            //propertyler buraya yazılacak 
            //command.TrendyolProductLastSocialProofName = "test";

            _trendyolProductLastSocialProofRepository.Setup(x => x.Query())
                                           .Returns(new List<TrendyolProductLastSocialProof> { new TrendyolProductLastSocialProof() { /*TODO:propertyler buraya yazılacak TrendyolProductLastSocialProofId = 1, TrendyolProductLastSocialProofName = "test"*/ } }.AsQueryable());

            _trendyolProductLastSocialProofRepository.Setup(x => x.Add(It.IsAny<TrendyolProductLastSocialProof>())).Returns(new TrendyolProductLastSocialProof());

            var handler = new CreateTrendyolProductLastSocialProofCommandHandler(_trendyolProductLastSocialProofRepository.Object, _mediator.Object);
            var x = await handler.Handle(command, new System.Threading.CancellationToken());

            x.Success.Should().BeFalse();
            x.Message.Should().Be(Messages.NameAlreadyExist);
        }

        [Test]
        public async Task TrendyolProductLastSocialProof_UpdateCommand_Success()
        {
            //Arrange
            var command = new UpdateTrendyolProductLastSocialProofCommand();
            //command.TrendyolProductLastSocialProofName = "test";

            _trendyolProductLastSocialProofRepository.Setup(x => x.GetAsync(It.IsAny<Expression<Func<TrendyolProductLastSocialProof, bool>>>()))
                        .ReturnsAsync(new TrendyolProductLastSocialProof() { /*TODO:propertyler buraya yazılacak TrendyolProductLastSocialProofId = 1, TrendyolProductLastSocialProofName = "deneme"*/ });

            _trendyolProductLastSocialProofRepository.Setup(x => x.Update(It.IsAny<TrendyolProductLastSocialProof>())).Returns(new TrendyolProductLastSocialProof());

            var handler = new UpdateTrendyolProductLastSocialProofCommandHandler(_trendyolProductLastSocialProofRepository.Object, _mediator.Object);
            var x = await handler.Handle(command, new System.Threading.CancellationToken());

            _trendyolProductLastSocialProofRepository.Verify(x => x.SaveChangesAsync());
            x.Success.Should().BeTrue();
            x.Message.Should().Be(Messages.Updated);
        }

        [Test]
        public async Task TrendyolProductLastSocialProof_DeleteCommand_Success()
        {
            //Arrange
            var command = new DeleteTrendyolProductLastSocialProofCommand();

            _trendyolProductLastSocialProofRepository.Setup(x => x.GetAsync(It.IsAny<Expression<Func<TrendyolProductLastSocialProof, bool>>>()))
                        .ReturnsAsync(new TrendyolProductLastSocialProof() { /*TODO:propertyler buraya yazılacak TrendyolProductLastSocialProofId = 1, TrendyolProductLastSocialProofName = "deneme"*/});

            _trendyolProductLastSocialProofRepository.Setup(x => x.Delete(It.IsAny<TrendyolProductLastSocialProof>()));

            var handler = new DeleteTrendyolProductLastSocialProofCommandHandler(_trendyolProductLastSocialProofRepository.Object, _mediator.Object);
            var x = await handler.Handle(command, new System.Threading.CancellationToken());

            _trendyolProductLastSocialProofRepository.Verify(x => x.SaveChangesAsync());
            x.Success.Should().BeTrue();
            x.Message.Should().Be(Messages.Deleted);
        }
    }
}

