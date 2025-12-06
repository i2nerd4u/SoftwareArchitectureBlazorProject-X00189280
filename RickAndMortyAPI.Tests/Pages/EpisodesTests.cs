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
    public class EpisodesTests : TestContext
    {
        [Fact]
        public void Episodes_RendersTitle()
        {
            // Arrange
            Services.AddSingleton(CreateMockHttpClient());

            // Act
            var cut = Render<Episodes>();

            // Assert
            Assert.Contains("Rick and Morty Episodes", cut.Markup);
        }

        [Fact]
        public void Episodes_ShowsLoadingMessage()
        {
            // Arrange
            Services.AddSingleton(CreateMockHttpClient());

            // Act
            var cut = Render<Episodes>();

            // Assert
            Assert.Contains("Loading episodes", cut.Markup);
        }

        [Fact]
        public void Episodes_HasCorrectStructure()
        {
            // Arrange
            Services.AddSingleton(CreateMockHttpClient());

            // Act
            var cut = Render<Episodes>();

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
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("{\"info\":{\"next\":null},\"results\":[]}")
                });

            return new HttpClient(mockHandler.Object);
        }
    }
}
