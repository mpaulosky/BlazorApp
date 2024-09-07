// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     RegisterConnections.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazorApp
// Project Name :  BlazorApp
// =============================================

namespace BlazorApp.Extensions;

/// <summary>
///  ServiceCollectionExtensions
/// </summary>
public static partial class ServiceCollectionExtensions
{
	/// <summary>
	///  RegisterConnections
	/// </summary>
	/// <param name="services"></param>
	/// <param name="config"></param>
	/// <returns></returns>
	public static IServiceCollection RegisterConnections(this IServiceCollection services, ConfigurationManager config)
	{
		//var section = config.GetSection("MongoDbSettings");
		//ArgumentNullException.ThrowIfNull(nameof(section));
		//DatabaseSettings mongoSettings = section.Get<DatabaseSettings>()!;
		//services.AddSingleton<IDatabaseSettings>(mongoSettings);

		return services;
	}
}
