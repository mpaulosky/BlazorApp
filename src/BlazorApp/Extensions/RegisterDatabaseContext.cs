// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     RegisterDatabaseContext.cs
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
	///   RegisterDatabaseContext
	/// </summary>
	/// <param name="services">IServiceCollection</param>
	/// <returns>IServiceCollection</returns>
	public static IServiceCollection RegisterDatabaseContext(this IServiceCollection services)
	{
		//services.AddSingleton<IMongoDbContextFactory, MongoDbContextFactory>();

		return services;
	}
}
