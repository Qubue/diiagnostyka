using Diagonostyka.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Models;

namespace Diagonostyka.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly IUserCredentialManager _userCredentialManager;

    public AuthController(IUserCredentialManager userCredentialManager)
    {
        _userCredentialManager = userCredentialManager;
    }
    
    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login([FromBody] UserDto user, CancellationToken cancellationToken)
    {
        var token = await _userCredentialManager.GenerateJwtAsync(user, cancellationToken);
        
        return string.IsNullOrWhiteSpace(token) ? Unauthorized() : Ok(new LoginResponse(token));
    }
}