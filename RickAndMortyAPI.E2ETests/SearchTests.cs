using Microsoft.Playwright.NUnit;
using Microsoft.Playwright;

namespace RickAndMortyAPI.E2ETests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class SearchAndPagingTests : PageTest
{
    private const string BaseUrl = "https://localhost:7183";

    [Test]
    public async Task Search_WithValidInput_FiltersCharacters()
    {
        await Page.GotoAsync($"{BaseUrl}/characters");
        await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);
        await Page.Locator(".search-input").FillAsync("Rick");
        await Page.WaitForTimeoutAsync(500);
        var characterName = await Page.Locator(".character-name").First.TextContentAsync();
        Assert.That(characterName, Does.Contain("Rick"));
    }

    [Test]
    public async Task Search_WithShortInput_ShowsValidationError()
    {
        await Page.GotoAsync($"{BaseUrl}/characters");
        await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);
        await Page.Locator(".search-input").FillAsync("R");
        await Expect(Page.Locator(".error-text")).ToBeVisibleAsync();
    }

    [Test]
    public async Task Pagination_NextButton_ChangesPage()
    {
        await Page.GotoAsync($"{BaseUrl}/characters");
        await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);
        await Page.GetByRole(AriaRole.Button, new() { Name = "Next" }).ClickAsync();
        await Expect(Page.Locator(".page-info")).ToContainTextAsync("Page 2");
    }

    [Test]
    public async Task Pagination_PreviousButton_DisabledOnFirstPage()
    {
        await Page.GotoAsync($"{BaseUrl}/characters");
        await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);
        var prevButton = Page.GetByRole(AriaRole.Button, new() { Name = "Previous" });
        await Expect(prevButton).ToBeDisabledAsync();
    }
}
