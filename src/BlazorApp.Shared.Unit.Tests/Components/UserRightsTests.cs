// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     UserRightsTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazorApp
// Project Name :  BlazorApp.Shared.Unit.Tests
// =============================================

using System.Diagnostics.CodeAnalysis;

namespace BlazorApp.Shared.Components;

[ExcludeFromCodeCoverage]
public class UserRightsTests : TestContext
{
	[Fact]
	public void UserRights_With_ASingleRole_Should_DisplayTheResult_Test()
	{
		// Arrange

		const string expected =
			"""
			<ul>
			  <li>Hi TEST USER, you have these claims and rights:</li>
			  <li>You have the role USER</li>
			</ul>
			""";

		var authContext = this.AddTestAuthorization();
		authContext.SetAuthorized("TEST USER");
		authContext.SetRoles("User");

		// Act

		var cut = RenderComponent<UserRights>();

		// Assert

		cut.MarkupMatches(expected);
	}

	[Fact]
	public void UserRights_With_MultipleRoles_Should_DisplayTheResult_Test()
	{
		// Arrange

		const string expected =
			"""
			<ul>
			  <li>Hi TEST USER, you have these claims and rights:</li>
			  <li>You have the role USER</li>
			  <li>You have the role ADMIN</li>
			</ul>
			""";

		var authContext = this.AddTestAuthorization();
		authContext.SetAuthorized("TEST USER");
		authContext.SetRoles("Admin", "User");

		// Act

		var cut = RenderComponent<UserRights>();

		// Assert

		cut.MarkupMatches(expected);
	}
}
