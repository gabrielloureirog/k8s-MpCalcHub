using Moq;
using Xunit;
using MPCalcDeleterProducer.Controllers;
using MPCalcDeleterProducer.Services;

public class DeleterControllerUnitTests
{
    private readonly Mock<IRabbitMqService> _rabbitMqServiceMock;
    private readonly DeleterController _controller;

    public DeleterControllerUnitTests()
    {
        _rabbitMqServiceMock = new Mock<IRabbitMqService>();
        _controller = new DeleterController(_rabbitMqServiceMock.Object);
    }

    [Fact]
    public async Task SendMessage_WhenCalled_CallsRabbitMqServiceAsync_AnyString()
    {
        // Arrange
        string message = "Test message";
        _rabbitMqServiceMock.Setup(x => x.PublishMessageAsync(It.IsAny<string>()));

        // Act
        await _controller.DeleteInQueue(message);

        // Assert
        _rabbitMqServiceMock.Verify(x => x.PublishMessageAsync(It.IsAny<string>()), Times.Once());
    }
}