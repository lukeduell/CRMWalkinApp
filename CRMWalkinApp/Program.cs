using CRMWalkinApp.Components;
using CRMWalkinApp.Models;
using CRMWalkinApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
var projectId = builder.Configuration["Firebase:ProjectId"];
var relativePath = builder.Configuration["Firebase:ServiceAccountPath"];
var serviceAccountFullPath = Path.Combine(AppContext.BaseDirectory, relativePath);
builder.Services.AddScoped(sp => new FirestoreService(projectId, serviceAccountFullPath));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapBlazorHub();

app.Run();
