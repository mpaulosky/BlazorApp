// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     MockHttpClientBunitHelpers.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazorApp
// Project Name :  BlazorApp.Unit.Tests
// =============================================

using System;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Net.Http;
using System.Text.Json;

using RichardSzalay.MockHttp;

using MediaTypeHeaderValue = System.Net.Http.Headers.MediaTypeHeaderValue;

namespace BlazorApp.Unit.Tests.Helpers;

[ExcludeFromCodeCoverage]
public static class MockHttpClientBunitHelpers
{
	public static MockHttpMessageHandler AddMockHttpClient(this TestServiceProvider services)
	{
		var mockHttpHandler = new MockHttpMessageHandler();
		var httpClient = mockHttpHandler.ToHttpClient();
		httpClient.BaseAddress = new Uri("http://localhost");
		services.AddSingleton(httpClient);
		return mockHttpHandler;
	}

	public static MockedRequest RespondJson<T>(this MockedRequest request, T content)
	{
		request.Respond(req =>
		{
			var response = new HttpResponseMessage(HttpStatusCode.OK);
			response.Content = new StringContent(JsonSerializer.Serialize(content));
			response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
			return response;
		});
		return request;
	}

	public static MockedRequest RespondJson<T>(this MockedRequest request, Func<T> contentProvider)
	{
		request.Respond(req =>
		{
			var response = new HttpResponseMessage(HttpStatusCode.OK);
			response.Content = new StringContent(JsonSerializer.Serialize(contentProvider()));
			response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
			return response;
		});
		return request;
	}
}
