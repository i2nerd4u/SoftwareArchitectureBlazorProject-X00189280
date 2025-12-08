# Playwright E2E Tests for Rick and Morty Blazor App

## Setup

1. Install Playwright browsers (Chromium already installed):
```bash
cd RickAndMortyAPI.E2ETests
powershell -ExecutionPolicy Bypass -File bin\Debug\net9.0\playwright.ps1 install chromium
```

## Running Tests

1. Start your Blazor app:
```bash
dotnet run --project ../RickAndMortyAPI.csproj
```

2. Run E2E tests:
```bash
dotnet test
```

## Test Structure

- `HomePageTests.cs` - Tests for home page navigation
- `CharacterListTests.cs` - Tests for character listing and navigation
- `EpisodesTests.cs` - Tests for episodes page

## Configuration

Update `BaseUrl` in test files if your app runs on a different port.
