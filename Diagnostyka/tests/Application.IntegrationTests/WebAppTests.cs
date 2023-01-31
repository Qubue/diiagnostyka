using System.Net;
using System.Net.Http.Json;
using Application.Identity;
using Diagonostyka.WebApi.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Xunit;

namespace Application.IntegrationTests;

public class WebAppTests
{
    [Fact]
    public async Task WebApi_Authenticate_Login_NotAuthorized()
    {
        await using var application = new WebApplicationFactory<Program>();
        using var client = application.CreateClient();

        var result = await client.PostAsync("auth/login", JsonContent.Create(new UserDto("userName", "password1")));

        result.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
    }
    
    [Fact]
    public async Task WebApi_Authenticate_Login_Obtain_Token()
    {
        await using var application = new WebApplicationFactory<Program>();
        using var client = application.CreateClient();
        
        var result = await client.PostAsync("auth/login", JsonContent.Create(new UserDto("userName", "password")));
        
        result.StatusCode.Should().Be(HttpStatusCode.OK);
        var content = await result.Content.ReadAsStringAsync();
        var response = JsonConvert.DeserializeObject<LoginResponse>(content); 
        response.Token.Should().NotBeNull();

    }
}