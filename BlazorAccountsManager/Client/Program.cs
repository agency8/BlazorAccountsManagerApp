global using BlazorAccountsManager.Client;
global using BlazorAccountsManager.Client.Helpers;
global using BlazorAccountsManager.Client.Services.AuthService;
global using BlazorAccountsManager.Client.Services.UserAccountManager;
global using BlazorAccountsManager.Shared.Helpers;
global using BlazorAccountsManager.Shared.Models;
global using BlazorAccountsManager.Shared.Dtos;
global using BlazorAccountsManager.Shared.Enums;
global using Blazored.LocalStorage;
global using System.Net.Http.Json;
global using System.Security.Claims;

using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUserAccountManager, UserAccountManager>();


builder.Services.AddBlazoredLocalStorage();
builder.Services.AddAuthorizationCore(config =>
{
	config.AddPolicy(Policies.IsSuperAdmin, Policies.IsSuperAdminPolicy());
	config.AddPolicy(Policies.IsAdmin, Policies.IsAdminPolicy());
	config.AddPolicy(Policies.IsUser, Policies.IsUserPolicy());
});
builder.Services.AddScoped<AuthenticationStateProvider, ApiAuthenticationStateProvider>();

await builder.Build().RunAsync();
