// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     LoginStatusTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazorApp
// Project Name :  BlazorApp.Shared.Unit.Tests
// =============================================

using System.Diagnostics.CodeAnalysis;

namespace BlazorApp.Shared.Security;

[ExcludeFromCodeCoverage]
public class LoginStatusTests : TestContext
{
	[Fact]
	public void LoginStatus_When_UserIsAuthenticated_Should_DisplaysLogoutLink_Test()
	{
		// Arrange

		const string expected =
			"""
			<a href="authentication/logout" class="nav-link">Logout</a>
			""";

		var authContext = this.AddTestAuthorization();
		authContext.SetAuthorized("TEST USER");

		// Act

		var cut = RenderComponent<LoginStatus>();

		// Assert

		cut.MarkupMatches(expected);
	}

	[Fact]
	public void LoginStatus_When_UserIsNotAuthenticated_Should_DisplaysLoginLink_Test()
	{
		// Arrange

		const string expected =
			"""
			<a href="Account/login?returnUrl=/" class="nav-link">Login</a>
			""";

		this.AddTestAuthorization();

		// Act

		var cut = RenderComponent<LoginStatus>();

		// Assert

		cut.MarkupMatches(expected);
	}
}
