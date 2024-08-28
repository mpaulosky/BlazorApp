﻿// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     PersistentAuthenticationStateProvider.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazorApp
// Project Name :  BlazorApp.Client
// =============================================

using System.Security.Claims;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace BlazorApp.Client;

internal class PersistentAuthenticationStateProvider : AuthenticationStateProvider
{
	private static readonly Task<AuthenticationState> defaultUnauthenticatedTask =
		Task.FromResult(new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity())));

	private readonly Task<AuthenticationState> authenticationStateTask = defaultUnauthenticatedTask;

	public PersistentAuthenticationStateProvider(PersistentComponentState state)
	{
		bool foundState = !state.TryTakeFromJson<UserInfo>(nameof(UserInfo), out UserInfo? userInfo);
		if (foundState || userInfo is null)
		{
			return;
		}

		List<Claim> claims = new();

		claims.Add(new Claim(ClaimTypes.NameIdentifier, userInfo.UserId));
		claims.Add(new Claim(ClaimTypes.Name, userInfo.Email ?? ""));
		claims.Add(new Claim(ClaimTypes.Email, userInfo.Email ?? ""));

		foreach (string role in userInfo.Roles)
		{
			claims.Add(new Claim(ClaimTypes.Role, role));
		}

		authenticationStateTask = Task.FromResult(
			new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(claims,
				nameof(PersistentAuthenticationStateProvider)))));
	}

	public override Task<AuthenticationState> GetAuthenticationStateAsync()
	{
		return authenticationStateTask;
	}
}