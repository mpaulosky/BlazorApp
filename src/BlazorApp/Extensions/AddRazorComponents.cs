// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     AddRazorComponents.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazorApp
// Project Name :  BlazorApp
// =============================================

namespace BlazorApp.Extensions;

/// <summary>
///  IServiceCollectionExtensions
/// </summary>
public static partial class ServiceCollectionExtensions
{
	public static WebApplicationBuilder AddRazorComponents(this WebApplicationBuilder builder)
	{
		builder.Services.AddRazorComponents()
			.AddInteractiveServerComponents()
			.AddInteractiveWebAssemblyComponents();

		return builder;
	}
}
