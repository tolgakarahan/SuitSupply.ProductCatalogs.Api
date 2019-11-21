using Application.Common.Interfaces;
using Application.ProductCatalogs.Commands.CreateProductCatalog;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTest.ProductCatalog.Commands.CreateProductCatalog
{

    public class CreateProductCatalogCommandTests
    {
        private Mock<IMediator> _mediatorMock;
        private Mock<IProductCatalogRepository> _productCatalogRepositoryMock;
        public CreateProductCatalogCommandTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _productCatalogRepositoryMock = new Mock<IProductCatalogRepository>();
        }

        [Fact]
        public void Handle_GivenValidRequest_ShouldRiseProductCatalogCreatedNotification()
        {
            // Arrange
            _productCatalogRepositoryMock
                .Setup(x => x.CreateProductCatalogAsync(It.IsAny<CreateProductCatalogCommand>(), CancellationToken.None))
                .Returns(Task.FromResult(1));

            // Act
            var handler =
                new CreateProductCatalogHandler(_productCatalogRepositoryMock.Object, _mediatorMock.Object);

            var result = handler.Handle(new CreateProductCatalogCommand { }, CancellationToken.None);

            // Assert
            _mediatorMock.Verify(m => m.Publish(It.Is<ProductCatalogCreated>(x => x.ProductCategoryId == 1), CancellationToken.None));
        }
    }
}
