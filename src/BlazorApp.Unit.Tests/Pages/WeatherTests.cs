// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     WeatherTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazorApp
// Project Name :  BlazorApp.Unit.Tests
// =============================================

using System.Diagnostics.CodeAnalysis;

using BlazorApp.Shared.Pages;

namespace BlazorApp.Unit.Tests.Pages;

[ExcludeFromCodeCoverage]
public class WeatherTests : TestContext
{
	[Fact]
	public void WeatherTest()
	{
		//Arrange

		const string expected =
			"""
			<h1>Weather</h1>
			<p>This component demonstrates showing data.</p>
			<p>
			  <em>Loading...</em>
			</p>
			""";

		//Act

		var cut = RenderComponent<Weather>();

		//Assert

		cut.MarkupMatches(expected);
	}
}
