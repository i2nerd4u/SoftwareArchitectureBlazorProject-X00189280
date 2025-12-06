using Bunit;
using Xunit;
using RickAndMortyAPI.Components.Pages;

namespace RickAndMortyAPI.Tests.Pages
{
    public class HomePageTests : TestContext
    {
        [Fact]
        public void HomePage_RendersCorrectly()
        {
            // Arrange & Act
            var cut = Render<Home>();

            // Assert
            Assert.Contains("Rick and Morty API Explorer", cut.Markup);
        }

        [Fact]
        public void HomePage_ContainsNavigationLinks()
        {
            // Arrange & Act
            var cut = Render<Home>();

            // Assert
            Assert.Contains("/Characters", cut.Markup);
            Assert.Contains("/Episodes", cut.Markup);
            Assert.Contains("/Analytics", cut.Markup);
        }

        [Fact]
        public void HomePage_DisplaysFeatureCards()
        {
            // Arrange & Act
            var cut = Render<Home>();

            // Assert
            Assert.Contains("Episodes Browser", cut.Markup);
            Assert.Contains("Character Database", cut.Markup);
            Assert.Contains("Data Analytics", cut.Markup);
        }

        [Fact]
        public void HomePage_DisplaysTechnicalCapabilities()
        {
            // Arrange & Act
            var cut = Render<Home>();

            // Assert
            Assert.Contains("About This Project", cut.Markup);
            Assert.Contains("Blazor Server", cut.Markup);
        }

        [Fact]
        public void HomePage_DisplaysAPIInformation()
        {
            // Arrange & Act
            var cut = Render<Home>();

            // Assert
            Assert.Contains("API Information", cut.Markup);
            Assert.Contains("rickandmortyapi.com", cut.Markup);
        }
    }
}
