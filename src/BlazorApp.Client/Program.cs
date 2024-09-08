// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     Program.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazorApp
// Project Name :  BlazorApp.Client
// =============================================

using BlazorApp.Client;
using BlazorApp.Shared.Security;
using BlazorApp.Shared.Services;

using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddSingleton<IBlazorTestService, ClientTestService>();

builder.Services.AddAuthorizationCore();

builder.Services.AddCascadingAuthenticationState();

builder.Services.AddSingleton<ILoginProvider, WebLoginProvider>();

builder.Services.AddSingleton<AuthenticationStateProvider, PersistentAuthenticationStateProvider>();

builder.Services.AddSingleton<IBlazorTestService, ClientTestService>();

builder.Services.AddSingleton<ILoginProvider, WebLoginProvider>();

await builder.Build().RunAsync();
