using Microsoft.Playwright.NUnit;
using Microsoft.Playwright;
using System.Text.RegularExpressions;

namespace RickAndMortyAPI.E2ETests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class HomePageTests : PageTest
{
    private const string BaseUrl = "https://localhost:7183";

    [Test]
    public async Task HomePage_LoadsSuccessfully()
    {
        await Page.GotoAsync(BaseUrl);
        await Expect(Page).ToHaveTitleAsync(new Regex("Rick.*Morty"));
    }

    [Test]
    public async Task HomePage_HasNavigationLinks()
    {
        await Page.GotoAsync(BaseUrl);
        await Expect(Page.GetByRole(AriaRole.Link, new() { Name = "Home" })).ToBeVisibleAsync();
        await Expect(Page.GetByRole(AriaRole.Link, new() { Name = "Characters" }).First).ToBeVisibleAsync();
    }
}
