using Microsoft.Playwright.NUnit;
using Microsoft.Playwright;

namespace RickAndMortyAPI.E2ETests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class EpisodesTests : PageTest
{
    private const string BaseUrl = "https://localhost:7183";

    [Test]
    public async Task Episodes_PageLoads()
    {
        await Page.GotoAsync($"{BaseUrl}/episodes");
        await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);
        await Expect(Page.Locator("body")).ToContainTextAsync("Episode", new() { Timeout = 10000 });
    }

    [Test]
    public async Task Episodes_DisplaysEpisodeList()
    {
        await Page.GotoAsync($"{BaseUrl}/episodes");
        await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);
        var episodes = Page.Locator("[class*='episode'], table tr, .list-group-item").First;
        await Expect(episodes).ToBeVisibleAsync(new() { Timeout = 10000 });
    }
}
