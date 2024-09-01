// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     LoginTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazorApp
// Project Name :  BlazorApp.Shared.Unit.Tests
// =============================================

using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace BlazorApp.Shared.Security;

[ExcludeFromCodeCoverage]
public class LoginTests : TestContext
{
	[Fact]
	public void Login_With_LoginProvider_Should_InvokesLoginProvider_Test()
	{
		// Arrange

		this.AddTestAuthorization();


		var loginProvider = new LoginProviderMock();

		Services.AddSingleton<ILoginProvider>(loginProvider);

		// Act

		var cut = RenderComponent<Login>();

		cut.Find("a").Click();

		// Assert

		Assert.True(loginProvider.LoginAsyncInvoked);
	}

	[Fact]
	public void Logout_With_LoginProvider_Should_InvokesLoginProvider_Test()
	{
		// Arrange

		var authContext = this.AddTestAuthorization();
		authContext.SetAuthorized("TEST USER");


		var loginProvider = new LoginProviderMock();

		Services.AddSingleton<ILoginProvider>(loginProvider);

		// Act

		var cut = RenderComponent<Login>();

		cut.Find("a").Click();

		// Assert

		Assert.True(loginProvider.LogoutAsyncInvoked);
	}
}

[ExcludeFromCodeCoverage]
public class LoginProviderMock : ILoginProvider
{
	public bool LoginAsyncInvoked { get; private set; }
	public bool LogoutAsyncInvoked { get; private set; }

	public Task LoginAsync()
	{
		LoginAsyncInvoked = true;
		return Task.CompletedTask;
	}

	public Task LogoutAsync()
	{
		LogoutAsyncInvoked = true;
		return Task.CompletedTask;
	}
}
