// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     ClientTestService.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazorApp
// Project Name :  BlazorApp.Shared
// =============================================

namespace BlazorApp.Shared.Services;

public class ClientTestService : IBlazorTestService
{
	public string GetMessage()
	{
		return "Hello from Blazor Client!";
	}
}