// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     WebLoginProviderTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazorApp
// Project Name :  BlazorApp.Client.Unit.Tests
// =============================================

using System.Threading.Tasks;

using FluentAssertions;

namespace BlazorApp.Client;

public class WebLoginProviderTests : TestContext
{
	[Fact]
	public async Task LoginAsync_NavigatesToLoginWithReturnUrl_Test()
	{
		// Arrange
		var navMan = Services.GetRequiredService<FakeNavigationManager>();
		var sut = new WebLoginProvider(navMan);

		// Act

		await sut.LoginAsync();

		// Assert

		sut.LoginAsync().Should().NotBeNull();
		navMan.Uri.Should().Be("http://localhost/Account/Login?returnUrl=/");
	}

	[Fact]
	public async Task LogoutAsync_NavigatesToLogout()
	{
		// Arrange

		var navMan = Services.GetRequiredService<FakeNavigationManager>();
		var sut = new WebLoginProvider(navMan);

		// Act

		await sut.LogoutAsync();

		// Assert

		sut.LogoutAsync().Should().NotBeNull();
		navMan.Uri.Should().Be("http://localhost/authentication/logout");
	}
}
