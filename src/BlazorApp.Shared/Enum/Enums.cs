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
	///   Status enum
	/// </summary>
	internal enum Status
	{
		Answered,
		Watching,
		Dismissed,
		InWork
	}
}
