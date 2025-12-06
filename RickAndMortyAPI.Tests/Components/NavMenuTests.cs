using Bunit;
using Xunit;
using RickAndMortyAPI.Components.Layout;

namespace RickAndMortyAPI.Tests.Components
{
    public class NavMenuTests : TestContext
    {
        [Fact]
        public void NavMenu_RendersAllLinks()
        {
            // Arrange & Act
            var cut = Render<NavMenu>();

            // Assert
            Assert.Contains("Home", cut.Markup);
            Assert.Contains("Episodes", cut.Markup);
            Assert.Contains("Characters", cut.Markup);
            Assert.Contains("Analytics", cut.Markup);
        }

        [Fact]
        public void NavMenu_HasCorrectBrandName()
        {
            // Arrange & Act
            var cut = Render<NavMenu>();

            // Assert
            Assert.Contains("RickAndMortyAPI", cut.Markup);
        }

        [Fact]
        public void NavMenu_ContainsNavigationStructure()
        {
            // Arrange & Act
            var cut = Render<NavMenu>();

            // Assert
            Assert.Contains("nav-item", cut.Markup);
            Assert.Contains("nav-link", cut.Markup);
        }
    }
}
