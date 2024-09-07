// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     Program.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazorApp
// Project Name :  BlazorApp
// =============================================

using BlazorApp.Extensions;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
	.AddInteractiveServerComponents()
	.AddInteractiveWebAssemblyComponents();

builder.Services.AddSingleton<IBlazorTestService, ServerTestService>();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<ILoginProvider, WebLoginProvider>();
builder.Services.AddScoped<AuthenticationStateProvider, PersistingServerAuthenticationStateProvider>();
builder.Services
	.AddAuth0WebAppAuthentication(options =>
	{
		options.Domain = builder.Configuration["Auth0:Authority"] ?? "";
		;
		options.ClientId = builder.Configuration["Auth0:ClientId"] ?? "";
	});

builder.Services.AddSingleton<IBlazorTestService, ServerTestService>();
builder.Services.AddScoped<ILoginProvider, WebLoginProvider>();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseWebAssemblyDebugging();
}
else
{
	app.UseExceptionHandler("/Error", true);
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
	.AddInteractiveServerRenderMode()
	.AddInteractiveWebAssemblyRenderMode()
	.AddAdditionalAssemblies(typeof(BlazorApp.Shared._Imports).Assembly);



app.AddAppSettings();

app.MapGet("account/login", async (string returnUrl, HttpContext context) =>
{
	var authenticationProperties = new LoginAuthenticationPropertiesBuilder()
		.WithRedirectUri(returnUrl)
		.Build();
	await context.ChallengeAsync(Auth0Constants.AuthenticationScheme, authenticationProperties);
});

app.MapGet("authentication/logout", async (HttpContext context) =>
{
	var authenticationProperties = new LogoutAuthenticationPropertiesBuilder()
		.WithRedirectUri("/")
		.Build();
	await context.SignOutAsync(Auth0Constants.AuthenticationScheme, authenticationProperties);
	await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
});

app.Run();
