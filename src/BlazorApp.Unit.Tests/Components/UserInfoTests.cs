// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     UserInfoTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazorApp
// Project Name :  BlazorApp.Unit.Tests
// =============================================

using System.Diagnostics.CodeAnalysis;
using BlazorApp.Shared.Components;

namespace BlazorApp.Unit.Tests.Components;

[ExcludeFromCodeCoverage]
public class UserInfoTests : TestContext
{
	[Fact]
	public void UserInfo_With_UnAuthenticatedAndUnAuthorizedState_Test()
	{
		// Arrange

		const string expected =
			"""
			<h1>Please log in!</h1>
			<p>State: Not authorized</p>
			""";

		this.AddTestAuthorization();

		// Act

		var cut = RenderComponent<UserInfo>();

		// Assert

		cut.MarkupMatches(expected);
	}

	[Fact]
	public void UserInfo_With_AuthenticatingAndAuthorizingState_Test()
	{
		// Arrange

		const string expected =
			"""
				<h1>Please log in!</h1>
				<p>State: Authorizing</p>
			""";

		var authContext = this.AddTestAuthorization();
		authContext.SetAuthorizing();

		// Act
		var cut = RenderComponent<UserInfo>();

		// Assert
		cut.MarkupMatches(expected);
	}

	[Fact]
	public void UserInfo_With_AuthenticatedAndUnauthorizedState_Test()
	{
		// Arrange

		const string expected =
			"""
				<h1>Welcome TEST USER</h1>
				<p>State: Not authorized</p>
			""";

		var authContext = this.AddTestAuthorization();
		authContext.SetAuthorized("TEST USER", AuthorizationState.Unauthorized);

		// Act
		var cut = RenderComponent<UserInfo>();

		// Assert
		cut.MarkupMatches(expected);
	}

	[Fact]
	public void UserInfo_With_AuthenticatedAndAuthorizingState_Test()
	{
		// Arrange

		const string expected =
			"""
				<h1>Welcome TEST USER</h1>
				<p>State: Authorized</p>
			""";

		var authContext = this.AddTestAuthorization();
		authContext.SetAuthorized("TEST USER");

		// Act
		var cut = RenderComponent<UserInfo>();

		// Assert

		cut.MarkupMatches(expected);
	}
}
