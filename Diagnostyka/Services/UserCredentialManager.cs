using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Services.Models;

namespace Services;

public class UserCredentialManager : IUserCredentialManager
{
    public Task<string> GenerateJwtAsync(UserDto user, CancellationToken cancellationToken)
    {
        if (user.UserName == "userName" && user.Password == "password")
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("someKeysomeKeysomeKeysomeKeysomeKeysomeKeysomeKey"));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokeOptions = new JwtSecurityToken(
                issuer: "https://localhost:7230/",
                audience: "https://localhost:7230/",
                claims: new List<Claim>(),
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: signinCredentials
            );

            return Task.FromResult(new JwtSecurityTokenHandler().WriteToken(tokeOptions));
        }

        return Task.FromResult(string.Empty);
    }
}