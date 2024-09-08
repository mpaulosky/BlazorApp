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
builder.ConfigureServices();

var app = builder.Build();

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
