// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     AddDiService.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazorApp
// Project Name :  BlazorApp
// =============================================

namespace BlazorApp.Extensions;

/// <summary>
///   IServiceCollectionExtensions
/// </summary>
public static partial class ServiceCollectionExtensions
{
	/// <summary>
	///   Add Authorization Services
	/// </summary>
	/// <param name="services">IServiceCollection</param>
	/// <returns>IServiceCollection</returns>
	public static IServiceCollection AddDiService(this IServiceCollection services)
	{
		services.AddSingleton<IBlazorTestService, ServerTestService>();
		services.AddScoped<ILoginProvider, WebLoginProvider>();


		return services;
	}
}
