// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     HomeTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazorApp
// Project Name :  BlazorApp.Shared.Unit.Tests
// =============================================

using System.Diagnostics.CodeAnalysis;
using BlazorApp.Shared.Services;

namespace BlazorApp.Shared.Pages;

[ExcludeFromCodeCoverage]
public class HomeTests : TestContext
{
	[Fact]
	public void Home_With_ServerTestService_Should_AValidPage_Test()
	{
		//Arrange

		const string expected =
			"""
			<h1>Hello, world!</h1>
			Welcome to your new app.
			<p>Hello from Blazor Server!</p>
			""";
		Services.AddSingleton<IBlazorTestService, ServerTestService>();

		//Act

		var cut = RenderComponent<Home>();

		//Assert

		cut.MarkupMatches(expected);
	}

	[Fact]
	public void Home_With_ClientTestService_Should_AValidPage_Test()
	{
		//Arrange

		const string expected =
			"""
			<h1>Hello, world!</h1>
			Welcome to your new app.
			<p>Hello from Blazor Client!</p>
			""";
		Services.AddSingleton<IBlazorTestService, ClientTestService>();

		//Act

		var cut = RenderComponent<Home>();

		//Assert

		cut.MarkupMatches(expected);
	}
}
