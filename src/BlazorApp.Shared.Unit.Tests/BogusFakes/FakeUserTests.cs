// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     FakeUserTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazorApp
// Project Name :  BlazorApp.Shared.Unit.Tests
// =============================================

using System.Diagnostics.CodeAnalysis;

using BlazorApp.Shared.Models;

using FluentAssertions;

namespace BlazorApp.Shared.BogusFakes;

[ExcludeFromCodeCoverage]
public class FakeUserTests
{
	[Theory(DisplayName = "FakeUser GetNewUser Tests")]
	[InlineData(true)]
	[InlineData(false)]
	public void GetNewUser_With_Boolean_Should_Return_With_Or_Without_An_Id_Test(bool expected)
	{
		// Arrange

		var result = FakeUser.GetNewUser(expected);

		// Act

		// Assert
		if (!expected)
		{
			result.UserId.Should().BeEquivalentTo("");
		}
		else
		{
			result.UserId.Should().NotBeNullOrWhiteSpace();
		}

		result.Should().BeOfType<UserInfo>();
		result.Email.Should().NotBeNullOrWhiteSpace();
		result.Roles[0].Should().NotBeNullOrWhiteSpace();
	}

	[Theory(DisplayName = "FakeUser GetUsers Test")]
	[InlineData(1)]
	[InlineData(5)]
	public void GetUser_WhenUserRequested_Returns_FakeUser_Test(int expectedCount)
	{
		// Arrange

		var result = FakeUser.GetUsers(expectedCount);

		// Act

		// Assert
		result.Count.Should().Be(expectedCount);

		foreach (var user in result)
		{
			user.Should().BeOfType<UserInfo>();
			user.UserId.Should().NotBeNullOrWhiteSpace();
			user.Email.Should().NotBeNullOrWhiteSpace();
			user.Roles[0].Should().NotBeNullOrWhiteSpace();
		}
	}

	[Theory(DisplayName = "FakeUser GetBasicUsers Test")]
	[InlineData(1)]
	[InlineData(5)]
	public void GetBasicUser_WhenBasicUserRequested_Returns_FakeBasicUser_Test(int expectedCount)
	{
		// Arrange

		var result = FakeUser.GetBasicUser(expectedCount);

		// Act

		// Assert
		result.Count.Should().Be(expectedCount);

		foreach (var user in result)
		{
			user.Should().BeOfType<BasicUserModel>();
			user.UserId.Should().NotBeNullOrWhiteSpace();
			user.Email.Should().NotBeNullOrWhiteSpace();
			user.Roles[0].Should().NotBeNullOrWhiteSpace();
		}
	}

	[Theory(DisplayName = "FakeUser GetNewUser With New Seed Tests")]
	[InlineData(true)]
	[InlineData(false)]
	public void GetNewUser_With_BooleanAndWithNewSeed_Should_Return_With_Or_Without_An_Id_Test(bool expected)
	{
		// Arrange

		var result = FakeUser.GetNewUser(expected, true);

		// Act

		// Assert
		if (!expected)
		{
			result.UserId.Should().BeNullOrWhiteSpace();
		}

		result.Should().NotBeEquivalentTo(FakeUser.GetNewUser(expected, true));
	}

	[Theory(DisplayName = "FakeUser GetUsers With New Seed Test")]
	[InlineData(1)]
	[InlineData(5)]
	public void GetUser_With_NumberRequestedAndWithNewSeed_Returns_FakeUser_Test(int expectedCount)
	{
		// Arrange

		// Act
		var result = FakeUser.GetUsers(expectedCount, true);

		// Assert
		result.Count.Should().Be(expectedCount);
		result.Should().NotBeEquivalentTo(FakeUser.GetUsers(expectedCount, true));
	}

	[Theory(DisplayName = "FakeUser GetBasicUsers With New Seed Test")]
	[InlineData(1)]
	[InlineData(5)]
	public void GetBasicUser_With_NumberRequestedAndWithNewSeed_Returns_FakeBasicUser_Test(int expectedCount)
	{
		// Arrange

		// Act
		var result = FakeUser.GetBasicUser(expectedCount, true);

		// Assert
		result.Count.Should().Be(expectedCount);
		result.Should().NotBeEquivalentTo(FakeUser.GetBasicUser(expectedCount, true));
	}
}
