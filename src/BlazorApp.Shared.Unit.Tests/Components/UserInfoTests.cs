// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     UserInfoTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazorApp
// Project Name :  BlazorApp.Shared.Unit.Tests
// =============================================

using System.Diagnostics.CodeAnalysis;

namespace BlazorApp.Shared.Components;

[ExcludeFromCodeCoverage]
public class UserInfoTests : TestContext
{
	[Fact]
	public void UserInfo_With_UnAuthenticatedAndUnAuthorizedState_Test()
	{
		// Arrange

		const string expected =
			"""
			<span class="umauthorized">Please log in!</span>
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
			<spam class="authorized">State: Authorizing</spam>
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
			<span class="umauthorized">Please log in!</span>
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
			<span class="authorized">Welcome TEST USER</span>
			""";

		var authContext = this.AddTestAuthorization();
		authContext.SetAuthorized("TEST USER");

		// Act
		var cut = RenderComponent<UserInfo>();

		// Assert

		cut.MarkupMatches(expected);
	}
}
