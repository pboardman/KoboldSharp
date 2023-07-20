using Moq.Protected;
using Moq;
using System.Net;
using System.Text;
using Xunit;

namespace KoboldSharp.Tests
{
    public class KoboldClientTests
    {
        [Fact]
        public async Task Generate_ShouldReturnCorrectModelOutput_WhenResponseIsSuccessful()
        {
            string jsonOutput = @"
            {
                ""results"": [
                    {
                        ""text"": ""Welcome to the testing ground.""
                    }
                ]
            }";

            // Arrange
            var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            handlerMock
               .Protected()
               .Setup<Task<HttpResponseMessage>>(
                  "SendAsync",
                  ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>()
               )
               .ReturnsAsync(new HttpResponseMessage()
               {
                   StatusCode = HttpStatusCode.OK,
                   Content = new StringContent(
                       jsonOutput,
                       Encoding.UTF8,
                       "application/json"),
               })
               .Verifiable();

            var httpClient = new HttpClient(handlerMock.Object);
            var koboldClient = new KoboldClient("http://test.com", httpClient);

            // Act
            var result = await koboldClient.Generate(new GenParams());

            // Assert
            Assert.NotNull(result);
            Console.WriteLine(result);
            Assert.Equal("Welcome to the testing ground.", result.Results[0].Text);
        }
    }
}
