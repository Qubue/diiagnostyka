namespace Application.Identity;

public interface IUserCredentialManager
{
    Task<string> GenerateJwtAsync(UserDto user, CancellationToken cancellationToken);
}