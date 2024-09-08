// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     ErrorPageTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazorApp
// Project Name :  BlazorApp.Unit.Tests
// =============================================

using System.Diagnostics.CodeAnalysis;
using BlazorApp.Components.Pages;

using Microsoft.AspNetCore.Http;

namespace BlazorApp.Components;

[ExcludeFromCodeCoverage]
public class ErrorPageTests : TestContext
{
	[Fact]
	public void ErrorPage_With_NoError_Should_DisplaysDefaultErrorMessage_Test()
	{
		// Arrange
		const string expected =
			"""
			<h1 class="text-danger">Error.</h1>
			<h2 class="text-danger">An error occurred while processing your request.</h2>
			<h3>Development Mode</h3>
			<p>
			  Swapping to
			  <strong>Development</strong>
			  environment will display more detailed information about the error that occurred.
			</p>
			<p>
			  <strong>The Development environment shouldn't be enabled for deployed applications.</strong>
			  It can result in displaying sensitive information from exceptions to end users.     For local debugging, enable the
			  <strong>Development</strong>
			  environment by setting the
			  <strong>ASPNETCORE_ENVIRONMENT</strong>
			  environment variable to
			  <strong>Development</strong>
			  and restarting the app.
			</p>
			""";

		var httpContextAccessor = new HttpContextAccessor
		{
			HttpContext = new DefaultHttpContext()
		};
		Services.AddSingleton<IHttpContextAccessor>(httpContextAccessor);

		// Act
		var cut = RenderComponent<Error>();

		// Assert
		cut.MarkupMatches(expected);
	}
}
