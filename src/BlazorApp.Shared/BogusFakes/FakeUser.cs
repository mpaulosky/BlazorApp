// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     FakeUser.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazorApp
// Project Name :  BlazorApp.Shared
// =============================================

using BlazorApp.Shared.Models;

using Bogus;

using MongoDB.Bson;

using static BlazorApp.Shared.Enum.Enums;

namespace BlazorApp.Shared.BogusFakes;

/// <summary>
///   FakeUser class
/// </summary>
public static class FakeUser
{
	/// <summary>
	///   Gets a new user.
	/// </summary>
	/// <param name="keepId">bool whether to keep the generated Id</param>
	/// <param name="useNewSeed">bool whether to use a seed other than 0</param>
	/// <returns>UserModel</returns>
	public static UserInfo GetNewUser(bool keepId = false, bool useNewSeed = false)
	{
		var user = GenerateFake(useNewSeed).Generate();

		if (!keepId)
		{
			user.UserId = string.Empty;
		}

		return user;
	}

	/// <summary>
	///   Gets a list of users.
	/// </summary>
	/// <param name="numberOfUsers">The number of users.</param>
	/// <param name="useNewSeed">bool whether to use a seed other than 0</param>
	/// <returns>A List of UserInfo</returns>
	public static List<UserInfo> GetUsers(int numberOfUsers, bool useNewSeed = false)
	{
		List<UserInfo>? users = GenerateFake(useNewSeed).Generate(numberOfUsers);

		return users;
	}

	/// <summary>
	///   Gets the basic user.
	/// </summary>
	/// <param name="numberOfUsers">The number of users.</param>
	/// <param name="useNewSeed">bool whether to use a seed other than 0</param>
	/// <returns>A List of BasicUserInfo</returns>
	public static List<BasicUserModel> GetBasicUser(int numberOfUsers, bool useNewSeed = false)
	{
		List<UserInfo>? users = GenerateFake(useNewSeed).Generate(numberOfUsers);

		return users.Select(c => new BasicUserModel(c)).ToList();
	}

	/// <summary>
	///   Generates a fake user.
	/// </summary>
	/// <param name="useNewSeed">bool whether to use a seed other than 0</param>
	/// <returns>A Faker UserModel</returns>
	private static Faker<UserInfo> GenerateFake(bool useNewSeed = false)
	{
		var seed = 0;
		if (useNewSeed)
		{
			seed = Random.Shared.Next(10, int.MaxValue);
		}

		var person = new Person();

		return new Faker<UserInfo>()
			.RuleFor((UserInfo x) => x.UserId, new BsonObjectId(ObjectId.GenerateNewId()).ToString())
			.RuleFor((UserInfo x) => x.UserName, person.UserName)
			.RuleFor((UserInfo x) => x.Roles, f => new[] { f.Random.Enum<Roles>().ToString() })
			.UseSeed(seed);
	}
}
