// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     PersistentAuthenticationStateProvider.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazorApp
// Project Name :  BlazorApp.Client
// =============================================

using System.Diagnostics.CodeAnalysis;
using System.Security.Claims;
using BlazorApp.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace BlazorApp.Client;

[ExcludeFromCodeCoverage]
internal class PersistentAuthenticationStateProvider : AuthenticationStateProvider
{
	private static readonly Task<AuthenticationState> _defaultUnauthenticatedTask =
		Task.FromResult(new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity())));

	private readonly Task<AuthenticationState> _AuthenticationStateTask = _defaultUnauthenticatedTask;

	public PersistentAuthenticationStateProvider(PersistentComponentState state)
	{
		var foundState = !state.TryTakeFromJson<UserInfo>(nameof(UserInfo), out var userInfo);
		if (foundState || userInfo is null)
		{
			return;
		}

		List<Claim> claims = new();

		claims.Add(new Claim(ClaimTypes.NameIdentifier, userInfo.UserId));
		claims.Add(new Claim(ClaimTypes.Name, userInfo.UserName!));

		foreach (var role in userInfo.Roles)
		{
			claims.Add(new Claim(ClaimTypes.Role, role));
		}

		_AuthenticationStateTask = Task.FromResult(
			new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(claims,
				nameof(PersistentAuthenticationStateProvider)))));
	}

	public override Task<AuthenticationState> GetAuthenticationStateAsync()
	{
		return _AuthenticationStateTask;
	}
}
