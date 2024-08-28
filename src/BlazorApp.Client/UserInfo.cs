// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     UserInfo.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazorApp
// Project Name :  BlazorApp.Client
// =============================================

namespace BlazorApp.Client;

public class UserInfo
{
	public required string UserId { get; set; }
	public required string Email { get; set; }
	public required string[] Roles { get; set; }
}