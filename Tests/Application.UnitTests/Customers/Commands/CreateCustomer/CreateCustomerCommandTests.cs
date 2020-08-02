using MediatR;
using Moq;
using RiSAT.Eshop.Application.Customers.Commands.CreateCustomer;
using System.Threading;
using RiSAT.Eshop.Application.UnitTests.Common;
using Xunit;

namespace RiSAT.Eshop.Application.UnitTests.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommandTests : CommandTestBase
    {
        [Fact]
        public void Handle_GivenValidRequest_ShouldRaiseCustomerCreatedNotification()
        {
            // Arrange
            var mediatorMock = new Mock<IMediator>();
            var sut = new CreateCustomerCommand.Handler(_context, mediatorMock.Object);
            var newCustomerId = "QAZQ1";

            // Act
            var result = sut.Handle(new CreateCustomerCommand { Id = newCustomerId }, CancellationToken.None);


            // Assert
            mediatorMock.Verify(m => m.Publish(It.Is<CustomerCreated>(cc => cc.CustomerId == newCustomerId), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
