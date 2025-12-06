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
    public class CharacterListTests : TestContext
    {
        [Fact]
        public void CharacterList_RendersTitle()
        {
            // Arrange
            Services.AddSingleton(CreateMockHttpClient());

            // Act
            var cut = Render<CharacterList>();

            // Assert
            Assert.Contains("Rick and Morty Characters", cut.Markup);
        }

        [Fact]
        public void CharacterList_DisplaysStatusFilters()
        {
            // Arrange
            Services.AddSingleton(CreateMockHttpClient());

            // Act
            var cut = Render<CharacterList>();

            // Assert
            Assert.Contains("All", cut.Markup);
            Assert.Contains("Alive", cut.Markup);
            Assert.Contains("Dead", cut.Markup);
            Assert.Contains("Unknown", cut.Markup);
        }

        [Fact]
        public void CharacterList_DisplaysLetterFilters()
        {
            // Arrange
            Services.AddSingleton(CreateMockHttpClient());

            // Act
            var cut = Render<CharacterList>();

            // Assert
            for (char c = 'A'; c <= 'Z'; c++)
            {
                Assert.Contains(c.ToString(), cut.Markup);
            }
        }

        [Fact]
        public void CharacterList_ShowsLoadingMessage()
        {
            // Arrange
            Services.AddSingleton(CreateMockHttpClient());

            // Act
            var cut = Render<CharacterList>();

            // Assert
            Assert.Contains("Loading characters", cut.Markup);
        }

        [Fact]
        public void CharacterList_HasCorrectRoutes()
        {
            // Arrange
            Services.AddSingleton(CreateMockHttpClient());

            // Act
            var cut = Render<CharacterList>();

            // Assert
            Assert.Contains("/Characters", cut.Markup);
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
