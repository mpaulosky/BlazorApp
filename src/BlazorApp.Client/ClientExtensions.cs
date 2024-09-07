// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     ClientExtensions.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazorApp
// Project Name :  BlazorApp.Client
// =============================================

using System.Diagnostics.CodeAnalysis;

using BlazorApp.Shared.Security;
using BlazorApp.Shared.Services;

using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace BlazorApp.Client;

/// <summary>
///  Client extensions.
/// </summary>
[ExcludeFromCodeCoverage]
public static class ClientExtensions
{
	/// <summary>
	/// Configure client services.
	/// </summary>
	/// <param name="builder"></param>
	public static void ConfigureClientServices(this WebAssemblyHostBuilder builder)
	{
		builder.Services.AddAuthorizationCore();
		builder.Services.AddCascadingAuthenticationState();
		builder.Services.AddSingleton<AuthenticationStateProvider, PersistentAuthenticationStateProvider>();
		builder.Services.AddSingleton<IBlazorTestService, ClientTestService>();
		builder.Services.AddSingleton<ILoginProvider, WebLoginProvider>();
	}
}
