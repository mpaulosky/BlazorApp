// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     Enums.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazorApp
// Project Name :  BlazorApp.Shared
// =============================================

namespace BlazorApp.Shared.Enum;

public class Enums
{
	/// <summary>
	///   Roles enum
	/// </summary>
	internal enum Roles
	{
		Author,
		Admin,
		User
	}

	/// <summary>
	/// Category enum
	/// </summary>
	public enum CategoryNames
	{
		AspNetCore = 0,
		BlazorServer = 1,
		BlazorWasm = 2,
		EntityFrameworkCore = 3,
		NetMaui = 4,
		Other = 5
	}
}
