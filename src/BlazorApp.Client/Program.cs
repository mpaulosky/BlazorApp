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

builder.ConfigureClientServices();

await builder.Build().RunAsync();
