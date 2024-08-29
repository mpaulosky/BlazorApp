// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     ILoginProvider.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazorApp
// Project Name :  BlazorApp.Shared
// =============================================

namespace BlazorApp.Shared.Security;

public interface ILoginProvider
{
	Task LoginAsync();
	Task LogoutAsync();
}