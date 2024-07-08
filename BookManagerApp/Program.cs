using BookManagerApp.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BookManagerApp.Data;
using Microsoft.AspNetCore.Identity;
using IgniteUI.Blazor.Controls;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<BookManagerAppContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BookManagerAppContext") ?? throw new InvalidOperationException("Connection string 'BookManagerAppContext' not found.")));

builder.Services.AddQuickGridEntityFrameworkAdapter();
builder.Services.AddIgniteUIBlazor(typeof(IgbDataGridModule));

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.
    AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).
    AddCookie();

builder.Services.AddScoped<AuthenticationStateProvider, ServerAuthenticationStateProvider>();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddAntiforgery(options =>
{     // Set Cookie properties using CookieBuilder properties†.

    options.Cookie.Expiration = TimeSpan.Zero;

});

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


app.UseAuthentication();
app.UseAuthorization();

app.UseAntiforgery();


app.MapRazorComponents<App>().DisableAntiforgery().AddInteractiveServerRenderMode();

app.Run();
