// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     UserRightsTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazorApp
// Project Name :  BlazorApp.Shared.Unit.Tests
// =============================================

using System.Diagnostics.CodeAnalysis;
using System.Security.Claims;

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
			<h1>Hi TEST USER, you have these claims and rights:</h1>
			<ul>
				<li>You have the role USER</li>
			</ul>
			""";

		var authContext = this.AddTestAuthorization();
		authContext.SetAuthorized("TEST USER");
		authContext.SetRoles("user");

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
			<h1>Hi TEST USER, you have these claims and rights:</h1>
			<ul>
				<li>You have the role USER</li>
				<li>You have the role ADMIN</li>
			</ul>
			""";

		var authContext = this.AddTestAuthorization();
		authContext.SetAuthorized("TEST USER");
		authContext.SetRoles("admin", "user");

		// Act

		var cut = RenderComponent<UserRights>();

		// Assert

		cut.MarkupMatches(expected);
	}

	[Fact]
	public void UserRights_With_ASinglePolicy_Should_DisplayTheResult_Test()
	{
		// Arrange

		const string expected =
			"""
			<h1>Hi TEST USER, you have these claims and rights:</h1>
			<ul>
			  <li>You are a CONTENT EDITOR</li>
			</ul>
			""";

		var authContext = this.AddTestAuthorization();
		authContext.SetAuthorized("TEST USER");
		authContext.SetPolicies("content-editor");

		// Act

		var cut = RenderComponent<UserRights>();

		// Assert

		cut.MarkupMatches(expected);
	}

	[Fact()]
	public void UserRights_With_MultipleClaimTypes_Should_DisplayTheResult_Test()
	{
		// Arrange

		const string expected =
			"""
			<h1>Hi TEST USER, you have these claims and rights:</h1>
			<ul>
				<li>Emailaddress: test@example.com</li>
				<li>Dateofbirth: 01-01-1970</li>
			</ul>
			""";

		var authContext = this.AddTestAuthorization();
		authContext.SetAuthorized("TEST USER");
		authContext.SetClaims(
			new Claim(ClaimTypes.Email, "test@example.com"),
			new Claim(ClaimTypes.DateOfBirth, "01-01-1970")
		);

		// Act

		var cut = RenderComponent<UserRights>();

		// Assert

		cut.MarkupMatches(expected);
	}

	[Fact]
	public void UserRights_With_ClaimsRolesAndPolicies_Should_DisplayTheResult_Test()
	{
		// Arrange

		const string expected =
			"""
			<h1>Hi TEST USER, you have these claims and rights:</h1>
			<ul>
				<li>Emailaddress: test@example.com</li>
				<li>You have the role USER</li>
				<li>You have the role ADMIN</li>
				<li>You are a CONTENT EDITOR</li>
			</ul
			""";

		var authContext = this.AddTestAuthorization();
		authContext.SetAuthorized("TEST USER");
		authContext.SetRoles("admin", "user");
		authContext.SetPolicies("content-editor");
		authContext.SetClaims(new Claim(ClaimTypes.Email, "test@example.com"));

		// Act

		var cut = RenderComponent<UserRights>();

		// Assert

		cut.MarkupMatches(expected);
	}

	[Fact()]
	public void UserRights_With_SetAuthenticationType_Should_DisplayTheType_Test()
	{
		// Arrange

		const string expected =
			"""
			<h1>Hi TEST USER, you have these claims and rights:</h1>
			<ul>
				<li>You have the authentication type CUSTOM AUTH TYPE</li>
			</ul>
			""";

		var authContext = this.AddTestAuthorization();
		authContext.SetAuthorized("TEST USER");
		authContext.SetAuthenticationType("custom-auth-type");

		// Act

		var cut = RenderComponent<UserRights>();

		// Assert

		cut.MarkupMatches(expected);
	}
}
