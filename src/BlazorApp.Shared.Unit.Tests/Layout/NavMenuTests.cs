// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     NavMenuTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazorApp
// Project Name :  BlazorApp.Shared.Unit.Tests
// =============================================

using System.Diagnostics.CodeAnalysis;

namespace BlazorApp.Shared.Layout;

[ExcludeFromCodeCoverage]
public class NavMenuTests : TestContext
{
	[Fact]
	public void NavMenuTest()
	{
		//Arrange

		const string expected =
				"""
				<div class="top-row ps-3 navbar navbar-dark" >
				  <div class="container-fluid" >
				    <a class="navbar-brand" href="" >BlazorApp</a>
				  </div>
				</div>
				<input type="checkbox" title="Navigation menu" class="navbar-toggler" >
				<div class="nav-scrollable" onclick="document.querySelector('.navbar-toggler').click()" >
				  <nav class="flex-column" >
				    <div class="nav-item px-3" >
				      <a href="" class="nav-link active" aria-current="page">
				        <span class="bi bi-house-door-fill-nav-menu" aria-hidden="true" ></span>
				        Home
				      </a>
				    </div>
				    <div class="nav-item px-3" >
				      <a href="counter" class="nav-link">
				        <span class="bi bi-plus-square-fill-nav-menu" aria-hidden="true" ></span>
				        Counter
				      </a>
				    </div>
				  </nav>
				</div>
				"""
			;

		//Act

		var cut = RenderComponent<NavMenu>();

		//Assert

		cut.MarkupMatches(expected);
	}
}
