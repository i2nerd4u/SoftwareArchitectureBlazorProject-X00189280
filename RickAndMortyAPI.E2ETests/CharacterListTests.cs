using Microsoft.Playwright.NUnit;
using Microsoft.Playwright;
using System.Text.RegularExpressions;

namespace RickAndMortyAPI.E2ETests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class CharacterListTests : PageTest
{
    private const string BaseUrl = "https://localhost:7183";

    [Test]
    public async Task CharacterList_LoadsCharacters()
    {
        await Page.GotoAsync($"{BaseUrl}/characters");
        await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);
        var characterCards = Page.Locator(".character-card, [class*='character']").First;
        await Expect(characterCards).ToBeVisibleAsync(new() { Timeout = 10000 });
    }

    [Test]
    public async Task CharacterList_CanNavigateToDetail()
    {
        await Page.GotoAsync($"{BaseUrl}/characters");
        await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);
        var firstCharacter = Page.Locator("a.character-name").First;
        await firstCharacter.ClickAsync(new() { Timeout = 60000 });
        await Expect(Page).ToHaveURLAsync(new Regex("/CharacterDetails/\\d+"), new() { Timeout = 10000 });
    }
}
