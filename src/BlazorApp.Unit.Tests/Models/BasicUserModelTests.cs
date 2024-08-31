// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     BasicUserModelTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazorApp
// Project Name :  BlazorApp.Unit.Tests
// =============================================

using System.Diagnostics.CodeAnalysis;
using BlazorApp.Shared.BogusFakes;
using BlazorApp.Shared.Models;
using FluentAssertions;

namespace BlazorApp.Unit.Tests.Models;

[ExcludeFromCodeCoverage]
public class BasicUserModelTests
{
	[Fact()]
	public void BasicUserModel_With_AUserInfo_Should_ReturnAValidBasicUserModel_Test()
	{
		//Arrange

		var user = FakeUser.GetNewUser(true);

		//Act

		var result = new BasicUserModel(user);


		//Assert

		result.Should().NotBeNull();
		result.UserName.Should().Be(user.UserName);
		result.UserId.Should().Be(user.UserId);
		result.Email.Should().Be(user.Email);
		result.Roles.Should().BeEquivalentTo(user.Roles);
	}

	[Fact()]
	public void BasicUserModel_With_ValuesFromAUserInfo_Should_Return_AValidBasicUserModel_Test()
	{
		//Arrange

		var user = FakeUser.GetNewUser(true);

		//Act

		var result = new BasicUserModel(user.UserName, user.UserId, user.Email, user.Roles);

		//Assert

		result.Should().NotBeNull();
		result.UserName.Should().Be(user.UserName);
		result.UserId.Should().Be(user.UserId);
		result.Email.Should().Be(user.Email);
		result.Roles.Should().BeEquivalentTo(user.Roles);
	}
}
