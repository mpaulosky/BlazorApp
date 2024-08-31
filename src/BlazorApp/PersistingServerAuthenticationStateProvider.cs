// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     PersistingServerAuthenticationStateProvider.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazorApp
// Project Name :  BlazorApp
// =============================================

using System.Diagnostics;
using BlazorApp.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace BlazorApp;

internal sealed class PersistingServerAuthenticationStateProvider : ServerAuthenticationStateProvider, IDisposable
{
	private readonly IdentityOptions _Options;

	private readonly PersistentComponentState _State;

	private readonly PersistingComponentStateSubscription _Subscription;

	private Task<AuthenticationState>? _AuthenticationStateTask;

	public PersistingServerAuthenticationStateProvider(
		PersistentComponentState persistentComponentState,
		IOptions<IdentityOptions> optionsAccessor)
	{
		_State = persistentComponentState;
		_Options = optionsAccessor.Value;

		AuthenticationStateChanged += OnAuthenticationStateChanged;
		_Subscription = _State.RegisterOnPersisting(OnPersistingAsync, RenderMode.InteractiveAuto);
	}

	public void Dispose()
	{
		_Subscription.Dispose();
		AuthenticationStateChanged -= OnAuthenticationStateChanged;
	}

	private void OnAuthenticationStateChanged(Task<AuthenticationState> task)
	{
		_AuthenticationStateTask = task;
	}

	private async Task OnPersistingAsync()
	{
		if (_AuthenticationStateTask is null)
		{
			throw new UnreachableException($"Authentication state not set in {nameof(OnPersistingAsync)}().");
		}

		var authenticationState = await _AuthenticationStateTask;
		var principal = authenticationState.User;

		if (principal.Identity?.IsAuthenticated == true)
		{
			var userName = principal.FindFirst(_Options.ClaimsIdentity.UserNameClaimType)?.Value;
			var userId = principal.FindFirst(_Options.ClaimsIdentity.UserIdClaimType)?.Value;
			var email = principal.FindFirst(_Options.ClaimsIdentity.EmailClaimType)?.Value;
			var roles = principal.FindAll(_Options.ClaimsIdentity.RoleClaimType);
			if (userId != null)
			{
				_State.PersistAsJson(nameof(UserInfo),
					new UserInfo
						{ UserName = userName, UserId = userId, Email = email!, Roles = roles.Select(r => r.Value).ToArray() });
			}
		}
	}
}
