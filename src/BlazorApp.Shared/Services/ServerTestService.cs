// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     ServerTestService.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazorApp
// Project Name :  BlazorApp.Shared
// =============================================

namespace BlazorApp.Shared.Services;

public class ServerTestService : IBlazorTestService
{
	public string GetMessage()
	{
		return "Hello from Blazor Server!";
	}
}