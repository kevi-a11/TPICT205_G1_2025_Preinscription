using GestionNotes.Blazor.Components;
using Blazored.LocalStorage;
using System.Net.Http;
using MudBlazor.Services;
using GestionNotes.Blazor.Models;
using GestionNotes.Blazor.Services;
using Microsoft.AspNetCore.Components.Server.Circuits;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddBlazoredLocalStorage();

// Ajouter des services au conteneur.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddMudServices(); // Enregistrer les services MudBlazor
builder.Services.AddHttpClient();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddSingleton<DatabaseContext>();
builder.Services.AddSingleton<CustomCircuitHandler>();
builder.Services.AddScoped<CircuitHandler>(sp => sp.GetRequiredService<CustomCircuitHandler>());
builder.Services.AddScoped<PreinscriptionService>();
builder.Services.AddScoped<PdfService>();
builder.Services.AddSingleton<StateService>();

// Ajouter le service HttpClient avec une adresse de base
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7294/") });

// Ajouter le logger
builder.Services.AddLogging(config =>
{
    config.AddConsole();
    config.AddDebug();
});

var app = builder.Build();

// Configurer le pipeline de requêtes HTTP.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // La valeur HSTS par défaut est de 30 jours. Vous pouvez vouloir changer cela pour les scénarios de production, voir https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
