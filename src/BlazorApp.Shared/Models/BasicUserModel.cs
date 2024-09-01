// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     BasicUserModel.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazorApp
// Project Name :  BlazorApp.Shared
// =============================================

namespace BlazorApp.Shared.Models;

/// <summary>
///   BasicUserModel class
/// </summary>
[Serializable]
public class BasicUserModel
{
	/// <summary>
	///  Initializes a new instance of the <see cref="BasicUserModel" /> class.
	/// </summary>
	public BasicUserModel()
	{
	}

	/// <summary>
	///   Initializes a new instance of the <see cref="BasicUserModel" /> class.
	/// </summary>
	/// <param name="user">The user.</param>
	public BasicUserModel(UserInfo user)
	{
		UserName = user.UserName;
		UserId = user.UserId;
		Email = user.Email;
		Roles = user.Roles;
	}

	/// <summary>
	///   Initializes a new instance of the <see cref="BasicUserModel" /> class.
	/// </summary>
	/// <param name="userName"></param>
	/// <param name="userId"></param>
	/// <param name="email"></param>
	/// <param name="roles"></param>
	public BasicUserModel(
		string userName,
		string userId,
		string email,
		string[] roles) : this()
	{
		UserName = userName;
		UserId = userId;
		Email = email;
		Roles = roles;
	}

	/// <summary>
	///  Gets or sets the user name.
	/// </summary>
	/// <value>
	/// The user name.
	/// </value>
	public string UserName { get; set; } = null!;

	/// <summary>
	///   Gets the identifier.
	/// </summary>
	/// <value>
	///   The identifier.
	/// </value>
	public string UserId { get; init; } = string.Empty;


	/// <summary>
	///   Gets or sets the email address.
	/// </summary>
	/// <value>
	///   The email address.
	/// </value>
	public string Email { get; init; } = string.Empty;

	/// <summary>
	/// Gets or sets the Roles
	/// </summary>
	/// <valure>
	///   The Roles
	/// </valure>
	public string[] Roles { get; init; } = [];
}
