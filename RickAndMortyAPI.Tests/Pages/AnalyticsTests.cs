using Bunit;
using Xunit;
using RickAndMortyAPI.Components.Pages;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Moq.Protected;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace RickAndMortyAPI.Tests.Pages
{
    public class AnalyticsTests : TestContext
    {
        [Fact]
        public void Analytics_RendersTitle()
        {
            // Arrange
            Services.AddSingleton(CreateMockHttpClient());

            // Act
            var cut = Render<Analytics>();

            // Assert
            Assert.Contains("Rick and Morty Analytics", cut.Markup);
        }

        [Fact]
        public void Analytics_ShowsContent()
        {
            // Arrange
            Services.AddSingleton(CreateMockHttpClient());

            // Act
            var cut = Render<Analytics>();

            // Assert
            Assert.Contains("Rick and Morty Analytics", cut.Markup);
        }

        [Fact]
        public void Analytics_HasStatCards()
        {
            // Arrange
            Services.AddSingleton(CreateMockHttpClient());

            // Act
            var cut = Render<Analytics>();

            // Assert
            Assert.Contains("stat-card", cut.Markup);
        }

        [Fact]
        public void Analytics_HasCorrectStructure()
        {
            // Arrange
            Services.AddSingleton(CreateMockHttpClient());

            // Act
            var cut = Render<Analytics>();

            // Assert
            Assert.NotNull(cut.Markup);
            Assert.NotEmpty(cut.Markup);
        }

        private HttpClient CreateMockHttpClient()
        {
            var mockHandler = new Mock<HttpMessageHandler>();
            mockHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(() => new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("{\"info\":{\"count\":0,\"next\":null},\"results\":[]}")
                });

            return new HttpClient(mockHandler.Object);
        }
    }
}
