# Deployment Guide

## Why Blazor Server (Not WASM)

This project uses **Blazor Server** instead of Blazor WASM for the following reasons:
- Better performance for data-heavy operations (826 characters from API)
- Smaller initial download size
- Better SEO capabilities
- Simpler deployment model
- Real-time updates via SignalR
- No CORS issues with external APIs

## Features Implemented

✅ **Interactive UI** - Filtering by status, species, gender, letter
✅ **Search with Validation** - Min 2 chars, max 50 chars
✅ **Paging** - 20 characters per page with next/previous
✅ **Error Handling** - Try-catch on API calls
✅ **E2E Testing** - Playwright tests for all features
✅ **CI/CD Pipeline** - GitHub Actions + Azure Pipelines
✅ **Code Coverage** - Integrated in test runs

## Deploy to Azure

### Option 1: Azure App Service

```bash
# Login to Azure
az login

# Create resource group
az group create --name RickMortyRG --location eastus

# Create app service plan
az appservice plan create --name RickMortyPlan --resource-group RickMortyRG --sku B1

# Create web app
az webapp create --name rickmorty-blazor-app --resource-group RickMortyRG --plan RickMortyPlan

# Deploy
dotnet publish -c Release
cd bin/Release/net8.0/publish
az webapp deployment source config-zip --resource-group RickMortyRG --name rickmorty-blazor-app --src publish.zip
```

### Option 2: Azure Static Web Apps (Requires WASM conversion)

Not applicable for Blazor Server.

## GitHub Actions Setup

1. Push code to GitHub
2. GitHub Actions will automatically:
   - Build the project
   - Run all tests (unit + E2E)
   - Generate code coverage
   - Publish test results

## Code Quality Metrics

Run locally:
```bash
dotnet test --collect:"XPlat Code Coverage"
```

Coverage reports in: `TestResults/*/coverage.cobertura.xml`
