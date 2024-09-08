// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     AllServicesToRegister.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazorApp
// Project Name :  BlazorApp
// =============================================

using System.Diagnostics.CodeAnalysis;


namespace BlazorApp.Extensions;

/// <summary>
///   RegisterServices class
/// </summary>
[ExcludeFromCodeCoverage]
public static class AllServicesToRegister
{
	/// <summary>
	///   Configures the services method.
	/// </summary>
	/// <param name="builder">The builder.</param>
	[ExcludeFromCodeCoverage]
	public static void ConfigureServices(this WebApplicationBuilder builder)
	{
		// Add services to the container.

		builder.AddRazorComponents();

		builder.AddAuthenticationService();

		builder.Services.AddDiService();

		//builder.Services.RegisterConnections();

		//builder.Services.RegisterDatabaseContext();

		//builder.Services.AddRazorPages();

		//builder.Services.AddMemoryCache();

		//builder.Services.AddControllersWithViews().AddMicrosoftIdentityUI();

		//builder.Services.AddBlazoredSessionStorage();
	}
}
