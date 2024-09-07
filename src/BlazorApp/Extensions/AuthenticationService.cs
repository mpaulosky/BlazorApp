// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     AuthenticationService.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazorApp
// Project Name :  BlazorApp
// =============================================

using System.Diagnostics.CodeAnalysis;

using Microsoft.AspNetCore.Components.Authorization;

namespace BlazorApp.Extensions;

/// <summary>
///   IServiceCollectionExtensions
/// </summary>
[ExcludeFromCodeCoverage]
public static partial class ServiceCollectionExtensions
{
	/// <summary>
	///   Add Authentication Services
	/// </summary>
	/// <param name="builder">WebApplicationBuilder</param>
	/// <returns>WebApplicationBuilder</returns>
	public static WebApplicationBuilder AddAuthenticationService(this WebApplicationBuilder builder)
	{
		ArgumentNullException.ThrowIfNull(builder);

		builder.Services.AddCascadingAuthenticationState();
		builder.Services.AddScoped<AuthenticationStateProvider, PersistingServerAuthenticationStateProvider>();

		builder.Services
			.AddAuth0WebAppAuthentication(options =>
			{
				options.Domain = builder.Configuration["Auth0:Authority"] ?? "";
				options.ClientId = builder.Configuration["Auth0:ClientId"] ?? "";
			});

		return builder;
	}
}
