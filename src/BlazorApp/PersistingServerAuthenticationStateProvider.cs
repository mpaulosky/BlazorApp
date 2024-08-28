// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     PersistingServerAuthenticationStateProvider.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazorApp
// Project Name :  BlazorApp
// =============================================

using System.Diagnostics;
using System.Security.Claims;

using BlazorApp.Client;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace BlazorApp;

internal sealed class PersistingServerAuthenticationStateProvider : ServerAuthenticationStateProvider, IDisposable
{
	private readonly IdentityOptions _options;
	private readonly PersistentComponentState _state;

	private readonly PersistingComponentStateSubscription _subscription;

	private Task<AuthenticationState>? _authenticationStateTask;

	public PersistingServerAuthenticationStateProvider(
		PersistentComponentState persistentComponentState,
		IOptions<IdentityOptions> optionsAccessor)
	{
		_state = persistentComponentState;
		_options = optionsAccessor.Value;

		AuthenticationStateChanged += OnAuthenticationStateChanged;
		_subscription = _state.RegisterOnPersisting(OnPersistingAsync, RenderMode.InteractiveAuto);
	}

	public void Dispose()
	{
		_subscription.Dispose();
		AuthenticationStateChanged -= OnAuthenticationStateChanged;
	}

	private void OnAuthenticationStateChanged(Task<AuthenticationState> task)
	{
		_authenticationStateTask = task;
	}

	private async Task OnPersistingAsync()
	{
		if (_authenticationStateTask is null)
		{
			throw new UnreachableException($"Authentication state not set in {nameof(OnPersistingAsync)}().");
		}

		AuthenticationState authenticationState = await _authenticationStateTask;
		ClaimsPrincipal principal = authenticationState.User;

		if (principal.Identity?.IsAuthenticated == true)
		{
			string? userId = principal.FindFirst(_options.ClaimsIdentity.UserIdClaimType)?.Value;
			string? email = principal.FindFirst(_options.ClaimsIdentity.EmailClaimType)?.Value;
			IEnumerable<Claim> roles = principal.FindAll(_options.ClaimsIdentity.RoleClaimType);
			if (userId != null)
			{
				_state.PersistAsJson(nameof(UserInfo),
					new UserInfo { UserId = userId, Email = email, Roles = roles.Select(r => r.Value).ToArray() });
			}
		}
	}
}