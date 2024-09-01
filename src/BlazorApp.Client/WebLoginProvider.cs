// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     WebLoginProvider.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazorApp
// Project Name :  BlazorApp.Client
// =============================================

using BlazorApp.Shared.Security;

using Microsoft.AspNetCore.Components;

namespace BlazorApp.Client;

public class WebLoginProvider(NavigationManager navMan) : ILoginProvider
{
	public Task LoginAsync()
	{
		navMan.NavigateTo("Account/Login?returnUrl=/", true);
		return Task.CompletedTask;
	}

	public Task LogoutAsync()
	{
		navMan.NavigateTo("authentication/logout", true);
		return Task.CompletedTask;
	}
}
