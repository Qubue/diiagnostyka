using Services.Models;

namespace Services;

public interface IUserCredentialManager
{
    Task<string> GenerateJwtAsync(UserDto user, CancellationToken cancellationToken);
}