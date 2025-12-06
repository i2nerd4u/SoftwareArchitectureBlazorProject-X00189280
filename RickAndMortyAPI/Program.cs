using RickAndMortyAPI.Components;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;


var builder = WebApplication.CreateBuilder(args);

// Register HttpClient properly
builder.Services.AddScoped(sp => new HttpClient());

// Add services for interactive Razor components (server-side interactive mode)
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

// Map interactive components (server render mode)
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
