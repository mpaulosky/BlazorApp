// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     Program.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazorApp
// Project Name :  BlazorApp.Client
// =============================================

using BlazorApp.Client;

using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

<<<<<<<<< Temporary merge branch 1
builder.Services.AddAuthorizationCore();

builder.Services.AddCascadingAuthenticationState();

builder.Services.AddSingleton<AuthenticationStateProvider, PersistentAuthenticationStateProvider>();
=========
builder.ConfigureClientServices();
>>>>>>>>> Temporary merge branch 2

builder.Services.AddSingleton<IBlazorTestService, ClientTestService>();

builder.Services.AddSingleton<ILoginProvider, WebLoginProvider>();

await builder.Build().RunAsync();
