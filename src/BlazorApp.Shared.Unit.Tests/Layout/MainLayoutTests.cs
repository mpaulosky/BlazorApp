// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     MainLayoutTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazorApp
// Project Name :  BlazorApp.Shared.Unit.Tests
// =============================================

using System.Diagnostics.CodeAnalysis;

using BlazorApp.Client;
using BlazorApp.Shared.BogusFakes;
using BlazorApp.Shared.Security;

namespace BlazorApp.Shared.Layout;

[ExcludeFromCodeCoverage]
public class MainLayoutTests : TestContext
{
	[Fact]
	public void MainLayout_Should_DisplayMainLayout_Test()
	{
		// Arrange

		const string expected =
			"""
			<div class="page" >
			  <div class="sidebar" >
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
			  </div>
			  <main >
			    <div class="top-row px-4" >
			      Not Authorised
			      <a >Log out</a>
			    </span>
			    <article class="content px-4" ></article>
			  </main>
			</div>
			<div id="blazor-error-ui" >
			  An unhandled error has occurred.
			  <a href="" class="reload" >Reload</a>
			  <a class="dismiss" >🗙</a>
			</div>
			""";

		var user = FakeUser.GetNewUser(true);

		var authContext = this.AddTestAuthorization();
		authContext.SetAuthorized(user.UserName!);
		authContext.SetRoles(user.Roles);

		Services.AddSingleton<ILoginProvider, WebLoginProvider>();


		// Act

		var cut = RenderComponent<MainLayout>();

		// Assert

		cut.MarkupMatches(expected);
	}
}
